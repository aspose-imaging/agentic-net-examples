using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a web application needs to generate stylized product thumbnails stored as PNG BLOBs in a SQL database, a developer can use this code to emboss the images before serving them to users.
 * 2. When an enterprise document management system archives scanned PNG images in a database and wants to add a subtle 3‑D effect for visual inspection, the Emboss5x5 filter can be applied programmatically.
 * 3. When a mobile backend processes user‑uploaded PNG avatars saved as BLOBs and wants to create an embossed version for a special “highlight” theme, developers can invoke this routine.
 * 4. When a digital signage platform stores PNG graphics in a database and needs to apply a quick edge‑enhancement effect to make text stand out on screens, the Emboss5x5 convolution filter provides a lightweight solution.
 * 5. When a scientific imaging tool archives microscope PNG snapshots as BLOBs and requires an embossed overlay to emphasize surface details for reports, this C# code with Aspose.Imaging can automate the transformation.
 */