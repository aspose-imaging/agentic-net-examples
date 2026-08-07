using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputDir = "frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                IMultipageImage multipage = webPImage as IMultipageImage;
                int frameCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < frameCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    RasterImage frameImage;
                    if (multipage != null)
                    {
                        frameImage = multipage.Pages[i] as RasterImage;
                    }
                    else
                    {
                        frameImage = webPImage as RasterImage;
                    }

                    if (frameImage != null)
                    {
                        BmpOptions bmpOptions = new BmpOptions();
                        frameImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract each frame from an animated WebP file and convert them to BMP for legacy Windows applications.
 * 2. When a batch image processing pipeline must decompose a multi‑page WebP into separate bitmap files for further analysis or OCR.
 * 3. When a game asset pipeline requires converting WebP sprite animations into individual BMP frames to be used by a legacy engine that only supports BMP.
 * 4. When a digital archiving system must preserve each frame of a WebP animation as lossless BMP files for long‑term storage and compliance.
 * 5. When a developer is troubleshooting visual artifacts by saving each WebP frame as a BMP to compare pixel data with other image processing tools.
 */