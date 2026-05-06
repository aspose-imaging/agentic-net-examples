using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX file paths
            string[] cmxPaths = new[]
            {
                @"C:\Images\input1.cmx",
                @"C:\Images\input2.cmx",
                @"C:\Images\input3.cmx"
            };

            // Hardcoded output path
            string outputPath = @"C:\Images\composite.png";

            // Verify input files exist
            foreach (string path in cmxPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first CMX to obtain canvas dimensions
            int canvasWidth, canvasHeight;
            using (CmxImage firstCmx = (CmxImage)Image.Load(cmxPaths[0]))
            {
                canvasWidth = firstCmx.Width;
                canvasHeight = firstCmx.Height;
            }

            // Create output source and PNG options
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Create raster canvas bound to the output source
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Process each CMX file in order
                foreach (string cmxPath in cmxPaths)
                {
                    // Temporary raster file for the current CMX
                    string tempRasterPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

                    // Rasterize CMX to PNG using vector rasterization options
                    using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
                    {
                        Source tempSource = new FileCreateSource(tempRasterPath, false);
                        PngOptions tempOptions = new PngOptions { Source = tempSource };
                        tempOptions.VectorRasterizationOptions = new CmxRasterizationOptions();
                        cmx.Save(tempRasterPath, tempOptions);
                    }

                    // Load the rasterized image and merge onto the canvas
                    using (RasterImage raster = (RasterImage)Image.Load(tempRasterPath))
                    {
                        Rectangle bounds = new Rectangle(0, 0, raster.Width, raster.Height);
                        canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                    }

                    // Delete temporary file
                    if (File.Exists(tempRasterPath))
                    {
                        File.Delete(tempRasterPath);
                    }
                }

                // Save the composite image (canvas is already bound to output source)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}