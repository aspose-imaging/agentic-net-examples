// HOW-TO: Convert PNG to JPEG and Ensure Output Size Under 5 MB in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            const string inputPath = "input.png";
            const string outputPath = "output.jpg";
            const long maxOutputSizeBytes = 5 * 1024 * 1024; // 5 MB

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new JpegOptions();
                    image.Save(outputPath, options);
                }

                FileInfo outInfo = new FileInfo(outputPath);
                if (outInfo.Length > maxOutputSizeBytes)
                {
                    Console.Error.WriteLine($"Output file size exceeds limit: {outInfo.Length} bytes > {maxOutputSizeBytes} bytes");
                }
                else
                {
                    Console.WriteLine($"Conversion successful. Output size: {outInfo.Length} bytes");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert user‑uploaded PNG avatars to JPEG thumbnails while guaranteeing the files stay below a 5 MB email attachment limit.
 * 2. When an automated batch process must shrink high‑resolution PNG graphics to JPEG for faster web page loading and must verify the resulting size does not exceed a predefined budget.
 * 3. When a desktop application creates JPEG previews of PNG drawings and must alert the user if the preview file would be too large for storage on a limited‑capacity device.
 * 4. When a cloud service transforms PNG product images to JPEG for CDN delivery and needs to enforce a maximum file size to meet bandwidth constraints.
 * 5. When a reporting tool exports charts as PNG, then converts them to JPEG for inclusion in PDFs, ensuring each image complies with the PDF’s size restrictions.
 */
