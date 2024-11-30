using CSharpEgitimKampi301.EFProject.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Frmstatistics : Form
    {
        public Frmstatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Frmstatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text=db.Location.Count().ToString();
            lblSumCapacity.Text= db.Location.Sum(x=>x.Capasity).ToString();
            lblGuideCount.Text= db.Guide.Count().ToString();
            lblAvgCapacity.Text= db.Location.Average(x=>x.Capasity).ToString();
            lblAvgLocationPrice.Text=db.Location.Average(x=>x.Price).ToString() + "$";

            int lastCountryId = db.Location.Max(x =>x. LocationId);
            lblLastCountryName.Text= db.Location. Where(x=>x.LocationId==lastCountryId).Select(x=>x.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "kapadokya").Select(y=>y.Capasity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text=db.Location.Where(x=>x.Country=="türkiye").Average(y=>y.Capasity).ToString();

            var romaguideId = db.Location.Where(x=>x.City=="roma").Select(y=>y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text=db.Guide.Where (X=>X.GuideId==romaguideId).Select(Y=>Y.GuideName +" "+ Y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity=db.Location.Max(x=>x.Capasity);
             lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capasity== maxCapacity).Select(Y=>Y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

            var guideIdByNameSıla = db.Guide.Where(x => x.GuideName == "sıla" && x.GuideSurname== "karataş").Select(Y => Y.GuideId).FirstOrDefault();
            lblsılalocationcount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameSıla).Count().ToString();

        }

        private void lblLastCountryName_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
           
        }

        private void lblMaxCapacityLocation_Click(object sender, EventArgs e)
        {

        }
    }
}
