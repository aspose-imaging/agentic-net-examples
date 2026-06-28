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
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output JPEG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage source = (RasterImage)image;
                    int width = source.Width;
                    int height = source.Height;

                    // Create a new raster image for the processed result (JPEG format)
                    using (RasterImage result = (RasterImage)Image.Create(new JpegOptions(), width, height))
                    {
                        // Sobel kernels for edge detection
                        int[,] gx = new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                        int[,] gy = new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                        const double threshold = 128.0;

                        // Process each pixel (skip the border pixels)
                        for (int y = 1; y < height - 1; y++)
                        {
                            for (int x = 1; x < width - 1; x++)
                            {
                                double sumX = 0;
                                double sumY = 0;

                                // Apply convolution kernels
                                for (int ky = -1; ky <= 1; ky++)
                                {
                                    for (int kx = -1; kx <= 1; kx++)
                                    {
                                        Aspose.Imaging.Color srcColor = source.GetPixel(x + kx, y + ky);
                                        // Convert to grayscale intensity
                                        double intensity = 0.299 * srcColor.R + 0.587 * srcColor.G + 0.114 * srcColor.B;

                                        sumX += intensity * gx[ky + 1, kx + 1];
                                        sumY += intensity * gy[ky + 1, kx + 1];
                                    }
                                }

                                // Gradient magnitude
                                double magnitude = Math.Sqrt(sumX * sumX + sumY * sumY);

                                // Edge pixel: white if above threshold, otherwise black
                                byte edge = magnitude > threshold ? (byte)255 : (byte)0;
                                Aspose.Imaging.Color edgeColor = Aspose.Imaging.Color.FromArgb(255, edge, edge, edge);
                                result.SetPixel(x, y, edgeColor);
                            }
                        }

                        // Set border pixels to black
                        for (int x = 0; x < width; x++)
                        {
                            result.SetPixel(x, 0, Aspose.Imaging.Color.Black);
                            result.SetPixel(x, height - 1, Aspose.Imaging.Color.Black);
                        }
                        for (int y = 0; y < height; y++)
                        {
                            result.SetPixel(0, y, Aspose.Imaging.Color.Black);
                            result.SetPixel(width - 1, y, Aspose.Imaging.Color.Black);
                        }

                        // Save the processed image as JPEG
                        result.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to convert a large set of legacy BMP scans into web‑friendly JPEGs while highlighting object outlines using a Sobel edge‑detection filter.
 * 2. When an automated image‑processing pipeline must read BMP files from a folder, apply custom convolution kernels for edge enhancement, and store the results as compressed JPEGs for faster download.
 * 3. When a C# application has to generate thumbnail previews of BMP engineering drawings with visible edges and save them in JPEG format for inclusion in reports.
 * 4. When a batch job is required to preprocess medical BMP images by detecting edges and outputting JPEGs that can be indexed by a PACS system.
 * 5. When a developer wants to integrate Aspose.Imaging into a Windows service that monitors an input directory, applies a custom edge detection kernel to each BMP, and writes the processed images as JPEGs to an output folder.
 */