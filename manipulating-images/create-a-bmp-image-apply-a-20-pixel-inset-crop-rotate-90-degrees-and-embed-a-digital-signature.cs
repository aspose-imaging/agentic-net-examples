using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

public class Program
{
    public static void Main(string[] args)
    {
        string outputPath = "output/output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (BmpImage bmp = new BmpImage(200, 200))
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int hue = (255 * x) / bmp.Width;
                    bmp.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                }
            }

            bmp.Crop(20, 20, 20, 20);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bmp.EmbedDigitalSignature("myPassword");
            bmp.Save(outputPath);
        }
    }
}