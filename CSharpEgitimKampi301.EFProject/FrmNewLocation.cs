using CSharpEgitimKampi301.EFProject.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmNewLocation : Form
    {
        public FrmNewLocation()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            ComboBox1.DisplayMember = "FullName";
            ComboBox1.ValueMember = "GuideId";
            ComboBox1.DataSource = "values";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capasity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(ComboBox1.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işi başarılı");

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCity.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işi başarılı");

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCity.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.Capasity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.GuideId = int.Parse(ComboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işi başarılı");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

