using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string iccProfilePath = "profile.icc";
        string outputPath = "output.jp2";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source PNG image
            using (Aspose.Imaging.Image sourceImage = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create JPEG2000 image from the raster source
                using (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image jp2Image = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image((Aspose.Imaging.RasterImage)sourceImage))
                {
                    // Note: Direct ICC profile embedding for JPEG2000 is not exposed via the API.
                    // This placeholder demonstrates where such logic would be applied if supported.

                    // Save JPEG2000 image
                    jp2Image.Save(outputPath, new Jpeg2000Options());
                }
            }

            // Load the saved JPEG2000 image to confirm it was saved correctly
            using (Aspose.Imaging.Image loadedJp2 = Aspose.Imaging.Image.Load(outputPath))
            {
                // Placeholder for ICC profile verification logic
                Console.WriteLine("JPEG2000 image saved successfully. ICC profile embedding verification not implemented.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}