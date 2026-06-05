using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path for the created BMP image
            string outputPath = "output/valid.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image of size 200x200 and fill it with white color
            using (BmpImage bmpImage = new BmpImage(200, 200))
            {
                Graphics graphics = new Graphics(bmpImage);
                graphics.Clear(Color.White);

                // Embed a digital signature with a valid password
                bmpImage.EmbedDigitalSignature("secure123");

                // Save the signed image
                bmpImage.Save(outputPath, new BmpOptions());
            }

            // Path to the image that will be used for the invalid signature attempt
            string inputPath = outputPath;

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the directory for the input path exists (required by the task)
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Load the image and attempt to embed a signature with a short password
            using (Image loadedImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)loadedImage;
                try
                {
                    raster.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}