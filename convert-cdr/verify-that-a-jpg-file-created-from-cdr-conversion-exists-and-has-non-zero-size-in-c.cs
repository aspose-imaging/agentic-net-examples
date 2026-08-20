// HOW-TO: Check JPEG Output Exists and Has Size After Converting CDR in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with vector rasterization settings
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }

            // Verify that the JPEG file was created and has non‑zero size
            if (File.Exists(outputPath))
            {
                long size = new FileInfo(outputPath).Length;
                if (size > 0)
                {
                    Console.WriteLine($"JPEG file created successfully. Size: {size} bytes.");
                }
                else
                {
                    Console.Error.WriteLine("JPEG file size is zero.");
                }
            }
            else
            {
                Console.Error.WriteLine("JPEG file was not created.");
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
 * 1. When an automated workflow converts CorelDRAW (.cdr) files to JPEGs and needs to confirm the output file was generated correctly before proceeding to the next step.
 * 2. When a batch processing script validates that each converted image is not empty, preventing downstream errors in a publishing pipeline.
 * 3. When a desktop application saves user‑edited CDR graphics as JPEG and must ensure the saved file exists and contains data before displaying it.
 * 4. When a CI/CD pipeline checks that image conversion jobs produce valid JPEG files with non‑zero size as part of quality‑gate testing.
 * 5. When a server‑side service processes uploaded CDR files and needs to verify successful JPEG creation to return a proper download link to the client.
 */
