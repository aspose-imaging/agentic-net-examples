// HOW-TO: Convert CMX to JPEG With White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display CorelDRAW CMX vector drawings on web pages that only support JPEG, you can convert them to JPEG with a solid white background to hide transparency.
 * 2. When generating thumbnails of CMX files for a document management system, you can rasterize the vectors to JPEG while ensuring transparent areas are filled to avoid visual artifacts.
 * 3. When automating batch processing of legacy CMX assets for a mobile app, you can use C# and Aspose.Imaging to convert each file to JPEG with a custom background color.
 * 4. When preparing print‑ready previews of CMX designs in a .NET application, you can render the vector image to JPEG and set the background to match the paper color.
 * 5. When integrating CMX support into an image‑upload workflow, you can convert incoming CMX files to JPEG on the server, applying a white background to maintain consistent appearance across browsers.
 */
