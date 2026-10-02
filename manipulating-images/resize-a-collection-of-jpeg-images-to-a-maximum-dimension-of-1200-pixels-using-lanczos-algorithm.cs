// HOW-TO: Resize JPEG Images to Max 1200 Pixels Using Lanczos in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.jpg"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;
                    int newWidth = originalWidth;
                    int newHeight = originalHeight;

                    const int maxDimension = 1200;

                    if (originalWidth >= originalHeight)
                    {
                        if (originalWidth > maxDimension)
                        {
                            newWidth = maxDimension;
                            newHeight = (int)(originalHeight * (maxDimension / (double)originalWidth));
                        }
                    }
                    else
                    {
                        if (originalHeight > maxDimension)
                        {
                            newHeight = maxDimension;
                            newWidth = (int)(originalWidth * (maxDimension / (double)originalHeight));
                        }
                    }

                    if (newWidth != originalWidth || newHeight != originalHeight)
                    {
                        image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    }

                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to batch‑resize a folder of JPEG photos for web galleries while preserving quality with the Lanczos filter.
 * 2. When you must ensure all uploaded user images fit within a 1200‑pixel limit before storing them in a CMS.
 * 3. When you want to generate thumbnail‑ready versions of product photos without distorting aspect ratios in a .NET application.
 * 4. When you are preparing images for email newsletters and need to reduce file size by limiting dimensions using Aspose.Imaging.
 * 5. When you automate image preprocessing for a machine‑learning pipeline that requires a consistent maximum size for JPEG inputs.
 */
