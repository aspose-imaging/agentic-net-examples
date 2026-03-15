using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files (replace with actual paths)
        List<string> jpgPaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Temporary folder for intermediate EMF files
        string tempFolder = Path.Combine(Path.GetTempPath(), "EmfTemp");
        Directory.CreateDirectory(tempFolder);

        // List to hold generated EMF file paths
        List<string> emfPaths = new List<string>();

        // Convert each JPG to EMF
        foreach (string jpgPath in jpgPaths)
        {
            // Load the raster JPG image
            using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
            {
                // Prepare EMF output path
                string emfPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".emf");

                // Create a FileCreateSource for the EMF file
                Source emfSource = new FileCreateSource(emfPath, false);

                // Configure EMF options with vector rasterization settings matching the raster size
                EmfOptions emfOptions = new EmfOptions
                {
                    Source = emfSource,
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = raster.Size
                    }
                };

                // Create a bound EMF canvas
                using (EmfImage emfCanvas = (EmfImage)Image.Create(emfOptions, raster.Width, raster.Height))
                {
                    // Draw the raster image onto the EMF canvas
                    Graphics graphics = new Graphics(emfCanvas);
                    graphics.DrawImage(raster, new Rectangle(0, 0, raster.Width, raster.Height));

                    // Save the EMF (bound image)
                    emfCanvas.Save();
                }

                emfPaths.Add(emfPath);
            }
        }

        // Determine PDF canvas size (max width, sum of heights)
        int pdfWidth = 0;
        int pdfHeight = 0;
        foreach (string emfPath in emfPaths)
        {
            using (EmfImage emf = (EmfImage)Image.Load(emfPath))
            {
                if (emf.Width > pdfWidth) pdfWidth = emf.Width;
                pdfHeight += emf.Height;
            }
        }

        // Prepare PDF output path
        string pdfOutputPath = "CombinedOutput.pdf";

        // Create PDF options with a bound source
        Source pdfSource = new FileCreateSource(pdfOutputPath, false);
        PdfOptions pdfOptions = new PdfOptions { Source = pdfSource };

        // Create a bound PDF canvas
        using (Image pdfCanvas = Image.Create(pdfOptions, pdfWidth, pdfHeight))
        {
            // Graphics object for drawing onto PDF
            Graphics pdfGraphics = new Graphics(pdfCanvas);

            int offsetY = 0;
            // Draw each EMF onto the PDF canvas vertically
            foreach (string emfPath in emfPaths)
            {
                using (EmfImage emf = (EmfImage)Image.Load(emfPath))
                {
                    pdfGraphics.DrawImage(emf, new Rectangle(0, offsetY, emf.Width, emf.Height));
                    offsetY += emf.Height;
                }
            }

            // Save the final PDF document
            pdfCanvas.Save();
        }

        // Cleanup temporary EMF files
        foreach (string emfPath in emfPaths)
        {
            File.Delete(emfPath);
        }
        Directory.Delete(tempFolder);
    }
}