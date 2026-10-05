// HOW-TO: Apply Edge Detection to Each Page of a Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output_pages";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(outputDirectory))
            {
                // Ensure the output directory exists (Path.GetDirectoryName will be null for a directory path,
                // so we create the directory directly).
                Directory.CreateDirectory(outputDirectory);
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;

                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    ((RasterImage)tiff).Filter(tiff.ActiveFrame.Bounds, filterOptions);

                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    using (TiffImage singlePage = (TiffImage)Image.Create(tiffOptions, frame.Width, frame.Height))
                    {
                        Color[] processedPixels = ((RasterImage)tiff).LoadPixels(frame.Bounds);
                        singlePage.SavePixels(singlePage.Bounds, processedPixels);
                        singlePage.Save();
                    }

                    pageIndex++;
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
 * 1. When you need to extract and enhance the outlines of every page in a scanned multipage TIFF for OCR preprocessing.
 * 2. When you want to generate separate TIFF files with edge‑enhanced content for archival or printing workflows.
 * 3. When you must apply a custom convolution kernel to each frame of a medical imaging TIFF series to highlight structures.
 * 4. When you are building a document‑analysis pipeline that requires per‑page edge detection before feature extraction.
 * 5. When you need to automate batch processing of multi‑page TIFFs to create individual pages with sharpened edges for visual inspection.
 */
