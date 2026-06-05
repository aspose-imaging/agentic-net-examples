using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GIF paths
            string gifPath1 = "input\\gif1.gif";
            string gifPath2 = "input\\gif2.gif";
            string gifPath3 = "input\\gif3.gif";

            // Verify each input file exists
            if (!File.Exists(gifPath1)) { Console.Error.WriteLine($"File not found: {gifPath1}"); return; }
            if (!File.Exists(gifPath2)) { Console.Error.WriteLine($"File not found: {gifPath2}"); return; }
            if (!File.Exists(gifPath3)) { Console.Error.WriteLine($"File not found: {gifPath3}"); return; }

            // Hardcoded output TIFF path (includes directory)
            string outputPath = "output\\multipage.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Determine canvas size from the first GIF
            int canvasWidth, canvasHeight;
            using (Image firstImg = Image.Load(gifPath1))
            {
                canvasWidth = firstImg.Width;
                canvasHeight = firstImg.Height;
            }

            // Prepare TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create the base TIFF image (contains a default frame)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
            {
                // Helper array of GIF paths
                string[] gifPaths = { gifPath1, gifPath2, gifPath3 };

                foreach (string gifPath in gifPaths)
                {
                    using (Image gifImg = Image.Load(gifPath))
                    {
                        // If the GIF is multipage, iterate its pages
                        if (gifImg is IMultipageImage multiGif && multiGif.PageCount > 0)
                        {
                            foreach (Image page in multiGif.Pages)
                            {
                                RasterImage raster = (RasterImage)page;
                                TiffFrame frame = new TiffFrame(raster);
                                tiffImage.AddFrame(frame);
                            }
                        }
                        else
                        {
                            // Single-frame GIF
                            RasterImage raster = (RasterImage)gifImg;
                            TiffFrame frame = new TiffFrame(raster);
                            tiffImage.AddFrame(frame);
                        }
                    }
                }

                // Remove the initial default frame
                TiffFrame activeFrame = tiffImage.ActiveFrame;
                if (tiffImage.Frames.Length > 1)
                {
                    tiffImage.ActiveFrame = tiffImage.Frames[1];
                    tiffImage.RemoveFrame(0);
                }
                activeFrame.Dispose();

                // Save the multipage TIFF (output already bound to source)
                tiffImage.Save();
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
 * 1. When a developer needs to combine several GIF images into a single multipage TIFF file for archival or high‑resolution printing using C# and Aspose.Imaging.
 * 2. When an application must convert a series of GIF screenshots into a multi‑page TIFF document that can be opened by standard TIFF viewers.
 * 3. When a workflow requires merging GIF frames into a TIFF to preserve image quality while reducing file size for email attachment or storage.
 * 4. When a reporting tool has to embed multiple GIF charts into one multipage TIFF for inclusion in PDF or printed reports.
 * 5. When a batch process must automate the creation of a multipage TIFF from a set of GIF assets for compliance documentation or record‑keeping.
 */