using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\highres.tif";
            string outputPath = "Output\\highres_embossed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)image;

                // Apply Emboss5x5 filter to the entire image
                tiff.Filter(tiff.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                // Save the result as PNG
                PngOptions pngOptions = new PngOptions();
                tiff.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate embossed preview thumbnails from high‑resolution TIFF scans for a web gallery, they can apply the Emboss5x5 filter and save the result as PNG.
 * 2. When preparing print‑ready TIFF artwork for an online catalog, a developer may emboss the image to highlight texture and then convert it to PNG for faster browser loading.
 * 3. When building a document‑management system that extracts visual cues from scanned TIFF documents, a developer can use the Emboss5x5 convolution filter in C# to emphasize edges before storing the output as PNG.
 * 4. When creating stylized map overlays from large TIFF satellite images, a developer can apply the Emboss5x5 filter to add depth perception and export the processed image as PNG for GIS applications.
 * 5. When automating batch processing of archival TIFF photographs, a developer can emboss each image to improve visual contrast and convert it to PNG for archival web display.
 */