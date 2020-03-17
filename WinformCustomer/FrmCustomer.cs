using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;
using InterfaceDal;
using FactoryDal;
namespace WinformCustomer
{
    public partial class FrmCustomer : Form
    {
        private CustomerBase cust = null;
        
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            DalLayer.Items.Add("ADODal");
            DalLayer.Items.Add("EFDal");
            DalLayer.SelectedIndex = 0;
            LoadGrid();
        }
        private void LoadGrid()
        {
            IDal<CustomerBase> Idal = FactoryDalLayer<IDal<CustomerBase>>.Create(DalLayer.Text);
            List<CustomerBase> custs = Idal.Search();
            dtgGridCustomer.DataSource = custs;

        }
        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = Factory<CustomerBase>.Create(cmbCustomerType.Text);
        }
        private void SetCustomer()
        {

            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = txtPhoneNumber.Text;
            cust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            cust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
            cust.Address = txtAddress.Text;
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                cust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetCustomer();
            IDal<CustomerBase> dal = FactoryDalLayer<IDal<CustomerBase>>
                                 .Create(DalLayer.Text);
            dal.Add(cust); // In memory
            dal.Save(); // Physical committ
            LoadGrid();
            ClearCustomer();
        }
        private void ClearCustomer()
        {
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            txtBillingDate.Text = DateTime.Now.Date.ToString();
            txtBillingAmount.Text = "";
            txtAddress.Text = "";
        }
        private void DalLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
