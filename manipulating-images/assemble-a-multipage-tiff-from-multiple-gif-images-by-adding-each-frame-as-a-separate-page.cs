// HOW-TO: Create Multipage TIFF From Multiple GIF Frames In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string inputPath1 = @"c:\temp\frame1.gif";
            string inputPath2 = @"c:\temp\frame2.gif";
            string inputPath3 = @"c:\temp\frame3.gif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Output TIFF path
            string outputPath = @"c:\temp\multipage.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Determine canvas size from the first GIF
            int canvasWidth, canvasHeight;
            using (Aspose.Imaging.Image firstImg = Aspose.Imaging.Image.Load(inputPath1))
            {
                canvasWidth = firstImg.Width;
                canvasHeight = firstImg.Height;
            }

            // Configure TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create the multipage TIFF image
            using (TiffImage tiffImage = (TiffImage)Aspose.Imaging.Image.Create(tiffOptions, canvasWidth, canvasHeight))
            {
                // Add each GIF as a separate TIFF frame
                string[] gifPaths = new[] { inputPath1, inputPath2, inputPath3 };
                foreach (string gifPath in gifPaths)
                {
                    // Create a TiffFrame directly from the GIF file
                    TiffFrame frame = new TiffFrame(gifPath);
                    tiffImage.AddFrame(frame);
                }

                // Remove the initially created blank frame
                TiffFrame initialFrame = tiffImage.ActiveFrame;
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
                initialFrame.Dispose();

                // Save the TIFF (output path already bound via FileCreateSource)
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
 * 1. When you need to combine several GIF frames into a single multi‑page TIFF using Aspose.Imaging for .NET for archival or printing purposes.
 * 2. When a document‑management workflow requires TIFF files but your source images are separate GIF files, and you want to generate the TIFF programmatically in C#.
 * 3. When generating a multi‑page report where each page is a GIF screenshot captured from a web application, and you need to assemble them into a TIFF document.
 * 4. When converting GIF assets into a TIFF stack for compatibility with legacy imaging software that only reads TIFF, using Aspose.Imaging’s TiffOptions.
 * 5. When creating a multi‑page fax or scanned document from individual GIF scans to meet regulatory file‑format standards in a C# application.
 */
