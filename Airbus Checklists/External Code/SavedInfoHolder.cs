using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Airbus_Checklists.Customization
{
    public class SavedInfoHolder
    {
        #region Background Color

        string saveDir = Directory.GetCurrentDirectory() + "/ProgramData/Saved/Customization";

        public void SaveBackgroundColor(float a , float r , float g , float b)
        {
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }

            StreamWriter generatedFile = new StreamWriter(saveDir + "/BackgroundColor.txt");

            generatedFile.WriteLine(a);
            generatedFile.WriteLine(r);
            generatedFile.WriteLine(g);
            generatedFile.WriteLine(b);
            generatedFile.WriteLine();
            generatedFile.WriteLine("// Tip :");
            generatedFile.WriteLine("   - 1st Value is the ALPHA channel of the color");
            generatedFile.WriteLine("   - 2nd Value is the RED channel of the color");
            generatedFile.WriteLine("   - 3rd Value is the GREEN channel of the color");
            generatedFile.WriteLine("   - 4th Value is the BLUE channel of the color");
            generatedFile.Close();
        }

        public Brush LoadBackgroundColor()
        {
            if (File.Exists(saveDir + "/BackgroundColor.txt") == false)
            {
                Color clr = new Color();
                clr.A = 255; clr.B = 255; clr.R = 255; clr.G = 255;
                Brush brushClr= (Brush)new SolidColorBrush(clr);

                return brushClr;
            }

            Color color = new Color();

            StreamReader fileReader = new StreamReader(saveDir + "/BackgroundColor.txt");

            float alpha = float.Parse(fileReader.ReadLine());
            float red = float.Parse(fileReader.ReadLine());
            float green = float.Parse(fileReader.ReadLine());
            float blue = float.Parse(fileReader.ReadLine());
            fileReader.Close();

            color.A = (byte)alpha;
            color.R = (byte)red;
            color.G = (byte)green;
            color.B = (byte)blue;

            Brush brushColor = (Brush)new SolidColorBrush(color);

            return brushColor;
        }

        #endregion
    }
}