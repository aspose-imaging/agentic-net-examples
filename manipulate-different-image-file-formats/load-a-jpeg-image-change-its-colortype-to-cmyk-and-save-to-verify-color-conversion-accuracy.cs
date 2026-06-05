using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_cmyk.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with CMYK color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk
                };

                // Save the image as CMYK JPEG
                image.Save(outputPath, saveOptions);
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
 * 1. When preparing print‑ready marketing materials, a developer can load a RGB JPEG, convert it to CMYK using Aspose.Imaging, and save the new file to ensure accurate colors for offset printing.
 * 2. When integrating a web service that receives user‑uploaded photos and must store them in a CMYK color space for downstream publishing workflows, this code can perform the conversion on the server side.
 * 3. When migrating a legacy asset library to a color‑managed workflow, a developer can batch‑process existing JPEGs by loading each image, changing its ColorType to CMYK, and saving the result to verify conversion fidelity.
 * 4. When building a desktop application that previews how a digital image will appear after conversion to CMYK for commercial printing, the code demonstrates the load‑convert‑save sequence using C# and Aspose.Imaging.
 * 5. When creating an automated quality‑control script that checks whether JPEG files are saved in the required CMYK color mode before sending them to a print vendor, this snippet can be used to enforce the correct color type.
 */