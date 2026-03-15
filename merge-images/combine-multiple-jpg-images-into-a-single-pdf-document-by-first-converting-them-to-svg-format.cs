using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpgToPdfViaSvg
{
    static void Main()
    {
        // Input JPG files
        string[] jpgFiles = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Folder for temporary SVG files
        string tempSvgFolder = Path.Combine(Path.GetTempPath(), "JpgToSvgTemp");
        Directory.CreateDirectory(tempSvgFolder);

        // List to hold generated SVG file paths
        List<string> svgFiles = new List<string>();

        // Convert each JPG to SVG
        foreach (string jpgPath in jpgFiles)
        {
            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare rasterization options (page size matches the source image)
                VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Define SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Determine SVG output path
                string svgPath = Path.Combine(tempSvgFolder,
                    Path.GetFileNameWithoutExtension(jpgPath) + ".svg");

                // Save as SVG
                jpgImage.Save(svgPath, svgOptions);

                // Store the SVG path for later PDF creation
                svgFiles.Add(svgPath);
            }
        }

        // Create a multipage image from the SVG files
        using (Image multiPageImage = Image.Create(svgFiles.ToArray()))
        {
            // Output PDF path
            string pdfOutputPath = @"C:\Images\CombinedOutput.pdf";

            // Save the multipage image as PDF.
            // Aspose.Imaging infers the format from the file extension.
            multiPageImage.Save(pdfOutputPath);
        }

        // Optional: clean up temporary SVG files
        foreach (string svgPath in svgFiles)
        {
            File.Delete(svgPath);
        }

        Directory.Delete(tempSvgFolder, true);
    }
}