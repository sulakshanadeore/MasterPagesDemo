﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bank_BAL;
using Bank_DAL;
namespace MasterPagesDemo
{
    public partial class InterestRates : System.Web.UI.Page
    {

        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnPreInit(e);
        //    this.MasterPageFile = "BankApp.Master";
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BankProds prods1 = new BankProds();
                List<Products> cprods = new List<Products>(); cprods = prods1.CalculatingInterest();
                foreach (var item in cprods)
                {
                    Products p = new Products();
                    p.Prodname = item.Prodname;
                    p.InterestRates = item.InterestRates;
                    DropDownList2.Items.Add
                    (new ListItem { Text = p.Prodname, Value = p.InterestRates.ToString() });

                }
            }


            BankProds prods = new BankProds();
            List<string> names = new List<string>();
            names=prods.ProductNames();
            DropDownList1.DataSource = names;
            DropDownList1.DataBind();


            
            






            List<Products> products = new List<Products>();
            products=prods.GetProducts();

            GridView1.DataSource = products;
            GridView1.DataBind();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue=="25days")
            {
                Response.Write("2%");//Pls use a label here
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rate=Convert.ToInt32
                (DropDownList2.SelectedValue);
            double amt=Convert.ToInt32(TextBox1.Text);
            double tenure= Convert.ToInt32(TextBox2.Text);
            TextBox4.Text = rate.ToString();
            double cAmt = (amt * tenure * rate) / 100;
            TextBox3.Text = cAmt.ToString();
        }
    }
}