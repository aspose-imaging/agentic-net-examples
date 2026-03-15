using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to combine
        string[] inputFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Temporary files for intermediate steps
        string tempJpegPath = "temp_merged.jpg";
        string tempEmfPath = "temp_intermediate.emf";
        string outputJpegPath = "combined_output.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create a JPEG canvas bound to a temporary file
        Source jpegSource = new FileCreateSource(tempJpegPath, false);
        JpegOptions jpegOpts = new JpegOptions() { Source = jpegSource, Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOpts, canvasWidth, canvasHeight))
        {
            // Merge each input image onto the canvas side by side
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged raster image as EMF (vector) using EmfOptions
            EmfOptions emfOpts = new EmfOptions()
            {
                VectorRasterizationOptions = new EmfRasterizationOptions()
                {
                    PageSize = canvas.Size
                }
            };
            canvas.Save(tempEmfPath, emfOpts);
        }

        // Load the intermediate EMF and save it as the final JPEG output
        using (Image emfImage = Image.Load(tempEmfPath))
        {
            JpegOptions finalJpegOpts = new JpegOptions() { Quality = 100 };
            emfImage.Save(outputJpegPath, finalJpegOpts);
        }

        // Cleanup temporary files (optional)
        // System.IO.File.Delete(tempJpegPath);
        // System.IO.File.Delete(tempEmfPath);
    }
}