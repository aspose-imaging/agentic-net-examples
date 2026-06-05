using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multipage TIFF
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Edge detection kernel (3x3)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Process each frame
                for (int i = 0; i < tiffImage.PageCount; i++)
                {
                    // Copy the current frame to avoid modifying the original image
                    TiffFrame frameCopy = TiffFrame.CopyFrame(tiffImage.Frames[i]);

                    // Create a temporary single-frame TIFF image
                    using (TiffImage singleFrameTiff = new TiffImage(frameCopy))
                    {
                        // Apply the convolution filter (edge detection) to the entire frame
                        singleFrameTiff.Filter(singleFrameTiff.Bounds, new ConvolutionFilterOptions(kernel));

                        // Prepare save options
                        TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Save the processed frame
                        singleFrameTiff.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to extract and enhance the edges of each page in a multi‑page TIFF scan (e.g., engineering drawings) for better visual inspection, they can use this C# Aspose.Imaging code to apply a convolution edge‑detection kernel to every frame and save the results as separate TIFF files.
 * 2. When building a document‑analysis pipeline that must preprocess scanned multi‑page TIFF invoices by highlighting text boundaries before OCR, this code demonstrates how to loop through each TIFF page, apply an edge detection filter, and store the processed pages.
 * 3. When creating a medical‑imaging workflow that requires sharpening the outlines of structures in each slice of a multi‑page TIFF DICOM conversion, developers can employ this example to run a 3×3 convolution filter on every frame using Aspose.Imaging for .NET.
 * 4. When automating quality‑control checks for printed circuit board (PCB) layouts stored as multi‑page TIFFs, the code shows how to programmatically detect edges on each layer to identify missing traces or defects.
 * 5. When developing a batch‑processing tool that converts archival multi‑page TIFF photographs into edge‑enhanced versions for archival preservation or artistic effect, this snippet provides the necessary steps to filter each page and save the output with TiffOptions.
 */