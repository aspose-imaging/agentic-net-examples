using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input CDR files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.cdr",
            @"C:\Images\input2.cdr",
            @"C:\Images\input3.cdr"
        };

        // Hard‑coded output multipage TIFF
        string outputPath = @"C:\Images\output.tif";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary folder for intermediate TIFF files
        string tempDir = @"C:\Images\temp";
        Directory.CreateDirectory(tempDir);

        // Collect all adjusted frames
        List<TiffFrame> adjustedFrames = new List<TiffFrame>();

        // Process each CDR file
        foreach (var inputPath in inputPaths)
        {
            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Iterate through all pages of the CDR document
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    // Save the page as a temporary TIFF file
                    string tempTiffPath = Path.Combine(tempDir, Guid.NewGuid().ToString() + ".tif");
                    page.Save(tempTiffPath, new TiffOptions(TiffExpectedFormat.Default));

                    // Load the temporary TIFF, adjust contrast, and store its frame
                    using (TiffImage tiffImage = (TiffImage)Image.Load(tempTiffPath))
                    {
                        // Adjust contrast (example value: 50)
                        tiffImage.AdjustContrast(50f);

                        // Keep the adjusted frame for later merging
                        adjustedFrames.Add(tiffImage.ActiveFrame);
                    }

                    // Optionally delete the temporary file
                    try { File.Delete(tempTiffPath); } catch { /* ignore cleanup errors */ }
                }
            }
        }

        // Ensure we have at least one frame to create the final TIFF
        if (adjustedFrames.Count == 0)
        {
            Console.Error.WriteLine("No frames were processed.");
            return;
        }

        // Create the final multipage TIFF using the first frame
        TiffImage finalTiff = new TiffImage(adjustedFrames[0]);

        // Append remaining frames
        for (int i = 1; i < adjustedFrames.Count; i++)
        {
            finalTiff.AddFrame(adjustedFrames[i]);
        }

        // Save the merged multipage TIFF
        finalTiff.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));

        // Cleanup
        finalTiff.Dispose();
    }
}