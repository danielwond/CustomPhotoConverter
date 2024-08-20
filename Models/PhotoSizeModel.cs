using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPhotoConverter.Models
{
    public class PhotoSizeModel
    {
        public PhotoSizeModel(double row, double column, double width, double height)
        {
            this.row = row;
            this.column = column;
            this.width = width;
            this.height = height;
        }
        public PhotoSizeModel(double width, double height, double amount)
        {
            this.Amount = amount;
            this.width = width;
            this.height = height;
        }
        public double width { get; set; }
        public double height { get; set; }
        public double row { get; set; }
        public double column { get; set; }
        public double Amount { get; set; }
    }
}
