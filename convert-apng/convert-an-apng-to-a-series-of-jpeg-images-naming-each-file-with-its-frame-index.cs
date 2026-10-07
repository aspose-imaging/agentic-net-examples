// HOW-TO: Extract Frames From APNG And Save As Indexed JPEGs In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                IMultipageImage multipage = apng as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                int frameCount = multipage.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    using (Image frame = (Image)multipage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.jpg");
                        string outDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrWhiteSpace(outDir))
                        {
                            Directory.CreateDirectory(outDir);
                        }

                        JpegOptions jpegOptions = new JpegOptions();
                        frame.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to break an animated PNG into individual JPEG images for use in a web gallery that only supports static JPEG files.
 * 2. When a game developer wants to convert each frame of an APNG sprite animation into separate JPEG assets for faster loading on low‑memory devices.
 * 3. When a reporting tool must embed each frame of an animated chart saved as APNG into PDF pages that only accept JPEG images.
 * 4. When a batch‑processing script has to archive every frame of an APNG as JPEG thumbnails with sequential filenames for easy indexing.
 * 5. When a legacy system requires JPEG input, you can extract the APNG frames and rename them with their frame index to feed into the older pipeline.
 */
