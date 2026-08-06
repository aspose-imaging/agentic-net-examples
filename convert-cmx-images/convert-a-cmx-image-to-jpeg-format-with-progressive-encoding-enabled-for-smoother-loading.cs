using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height,
                        BackgroundColor = Color.White
                    }
                };

                cmx.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX vector files to web‑friendly JPEG images with progressive encoding for smoother page loading.
 * 2. When an application must batch‑process CMX drawings and generate high‑quality JPEG previews that retain the original dimensions and a white background.
 * 3. When a .NET service is required to transform CMX artwork into progressive JPEGs for email newsletters, ensuring incremental rendering on low‑bandwidth connections.
 * 4. When a digital asset pipeline needs to rasterize CMX pages to JPEG format with quality = 100 while using progressive compression to keep file sizes manageable for archival storage.
 * 5. When a Windows desktop tool must load a CMX file, apply Aspose.Imaging’s VectorRasterizationOptions, and save it as a progressive JPEG for compatibility with browsers that only support raster images.
 */