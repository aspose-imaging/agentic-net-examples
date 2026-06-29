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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

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
                    jpegOptions.HorizontalSampling = new byte[] { 2, 1, 1 };
                    jpegOptions.VerticalSampling = new byte[] { 2, 1, 1 };

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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) to JPEG thumbnails for a web gallery and wants to preserve color fidelity by applying custom HorizontalSampling and VerticalSampling chroma subsampling.
 * 2. When an automated batch process must transform a collection of ODG diagrams into JPEG files for email attachments while reducing file size using specific 2,1,1 sampling arrays.
 * 3. When a reporting application exports vector drawings stored as ODG into JPEG images for PDF reports and requires explicit VectorRasterizationOptions such as BackgroundColor, PageWidth, and PageHeight.
 * 4. When a content management system ingests ODG files and needs to rasterize them to JPEG with Aspose.Imaging, setting custom chroma subsampling to meet corporate imaging standards.
 * 5. When a mobile app downloads ODG assets and converts them to JPEG on‑the‑fly in C#, using custom HorizontalSampling and VerticalSampling to ensure consistent color rendering across devices.
 */