// HOW-TO: Convert OTG Image To High‑Quality JPEG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When a .NET application must display or share OTG graphics on web pages that only support JPEG, developers can use this code to convert the files with maximum quality.
 * 2. When an image‑processing pipeline receives OTG files from a design tool and needs to archive them as compressed JPEGs for storage efficiency, this snippet automates the conversion.
 * 3. When a mobile app imports OTG assets and requires them in JPEG format for faster loading on devices, the code provides a straightforward C# solution.
 * 4. When a batch job processes a folder of OTG drawings and generates JPEG previews for client review, developers can employ this routine to produce high‑fidelity outputs.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded OTG files to JPEG for email attachments, this example shows the necessary steps.
 */
