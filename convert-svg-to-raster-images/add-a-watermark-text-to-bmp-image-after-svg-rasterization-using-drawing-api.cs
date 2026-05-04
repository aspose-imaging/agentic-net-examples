using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG and output BMP paths
            string inputPath = "input.svg";
            string outputPath = "output.bmp";
            string tempBmpPath = "temp.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist (null-safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            string tempDir = Path.GetDirectoryName(tempBmpPath);
            if (!string.IsNullOrEmpty(tempDir))
                Directory.CreateDirectory(tempDir);

            // Load SVG and rasterize to a temporary BMP file
            using (Image svgImage = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                svgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the rasterized BMP, add watermark text, and save final output
            using (RasterImage bmpImage = (RasterImage)Image.Load(tempBmpPath))
            {
                // Create Graphics for drawing
                Graphics graphics = new Graphics(bmpImage);

                // Define watermark text properties
                string watermarkText = "Watermark";
                Font font = new Font("Arial", 24, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(Color.White);
                Point location = new Point(10, bmpImage.Height - 30);

                // Draw the watermark text
                graphics.DrawString(watermarkText, font, brush, location);

                // Save the final BMP with watermark
                bmpImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}