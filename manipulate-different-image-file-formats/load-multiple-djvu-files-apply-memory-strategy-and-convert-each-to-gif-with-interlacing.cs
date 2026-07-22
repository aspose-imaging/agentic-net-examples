using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all DjVu files in the input directory
            string[] djvuFiles = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in djvuFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    LoadOptions loadOptions = new LoadOptions
                    {
                        BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer for memory strategy
                    };

                    using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
                    {
                        using (GifOptions gifOptions = new GifOptions())
                        {
                            gifOptions.Interlaced = true; // Enable interlacing
                            djvuImage.Save(outputPath, gifOptions);
                        }
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
 * 1. When a digital archive needs to batch‑convert scanned DjVu documents into web‑friendly interlaced GIFs while limiting memory usage.
 * 2. When an e‑learning platform must prepare lecture slides stored as DjVu files for fast progressive loading in browsers by converting them to interlaced GIFs.
 * 3. When a publishing workflow requires automated conversion of multi‑page DjVu manuscripts to GIF images for preview thumbnails without exhausting server RAM.
 * 4. When a mobile app backend processes user‑uploaded DjVu files and generates interlaced GIFs for responsive display on low‑bandwidth connections.
 * 5. When a legal firm wants to transform a collection of DjVu case files into GIFs with interlacing to embed in HTML reports while controlling memory consumption.
 */