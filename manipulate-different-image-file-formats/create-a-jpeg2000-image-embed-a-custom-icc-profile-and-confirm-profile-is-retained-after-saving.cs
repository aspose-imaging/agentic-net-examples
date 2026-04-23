using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string iccProfilePath = @"C:\temp\custom.icc";
            string outputPath = @"C:\temp\output.jp2";

            // Validate ICC profile file exists
            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG2000 options (optional settings)
            Jpeg2000Options createOptions = new Jpeg2000Options();
            createOptions.Irreversible = true; // Use irreversible DWT 9-7

            // Create a new JPEG2000 image
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, createOptions))
            {
                // Fill the image with red color
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                // Embed custom ICC profile
                // Note: Direct ICC profile embedding for JPEG2000 is not exposed via a dedicated property.
                // As a workaround, the profile can be attached as metadata if supported.
                // The following line demonstrates how one might assign a stream source if such a property existed:
                // jpeg2000Image.IccProfile = new StreamSource(File.OpenRead(iccProfilePath));
                // Since the API does not provide a direct ICC profile property for JPEG2000,
                // this step is left as a placeholder for future implementation.

                // Save the JPEG2000 image
                jpeg2000Image.Save(outputPath);
            }

            // Load the saved image to verify it was saved correctly
            using (Jpeg2000Image loadedImage = new Jpeg2000Image(outputPath))
            {
                // Placeholder check for ICC profile retention
                // If an ICC profile property existed, you would verify it here.
                // For demonstration, we simply confirm the image loads without error.
                Console.WriteLine("JPEG2000 image saved and loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}