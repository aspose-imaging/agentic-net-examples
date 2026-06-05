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
            // Define base, input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the vector image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare JPEG options (high quality)
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 100,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    // Prepare PNG options (lossless)
                    PngOptions pngOptions = new PngOptions
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

                    // Define output file paths
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string jpegOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                    string pngOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                    // Ensure output directories exist
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                    // Save as JPEG
                    image.Save(jpegOutputPath, jpegOptions);

                    // Save as PNG
                    image.Save(pngOutputPath, pngOptions);
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
 * 1. When a publishing company needs to generate both web‑optimized JPEG previews and print‑ready PNG files from a large collection of SVG or EPS artwork for their online catalog.
 * 2. When an e‑learning platform automatically converts instructor‑provided vector diagrams into high‑resolution JPEGs for fast loading in browsers and lossless PNGs for downloadable study material.
 * 3. When a marketing agency runs nightly batch jobs to rasterize client‑supplied AI files into 300 dpi JPEGs for email campaigns while also preserving the original quality in PNG for archival.
 * 4. When a CAD software vendor offers a command‑line tool that transforms batches of DWG vector drawings into JPEG thumbnails for quick preview and PNG assets for integration into third‑party design tools.
 * 5. When a digital asset management system needs to ingest a folder of mixed vector formats and produce dual‑format outputs—high‑quality JPEG for web galleries and PNG for lossless editing—using C# and Aspose.Imaging.
 */