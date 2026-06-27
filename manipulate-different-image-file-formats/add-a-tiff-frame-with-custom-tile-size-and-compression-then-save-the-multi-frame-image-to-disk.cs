using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path (hard‑coded)
            string outputPath = "output\\multi.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Options for the first frame
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
            options1.BitsPerSample = new ushort[] { 8, 8, 8 };
            options1.Photometric = TiffPhotometrics.Rgb;
            options1.Compression = TiffCompressions.Lzw;
            options1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create first frame (200x200) and fill with blue
            int width = 200;
            int height = 200;
            TiffFrame frame1 = new TiffFrame(options1, width, height);
            int[] bluePixels = Enumerable.Repeat(Aspose.Imaging.Color.Blue.ToArgb(), width * height).ToArray();
            ((RasterImage)frame1).SaveArgb32Pixels(frame1.Bounds, bluePixels);

            // Options for the second frame
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
            options2.BitsPerSample = new ushort[] { 8, 8, 8 };
            options2.Photometric = TiffPhotometrics.Rgb;
            options2.Compression = TiffCompressions.AdobeDeflate;
            options2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create second frame (200x200) and fill with green
            TiffFrame frame2 = new TiffFrame(options2, width, height);
            int[] greenPixels = Enumerable.Repeat(Aspose.Imaging.Color.Green.ToArgb(), width * height).ToArray();
            ((RasterImage)frame2).SaveArgb32Pixels(frame2.Bounds, greenPixels);

            // Assemble multi‑frame TIFF
            using (TiffImage tiffImage = new TiffImage(frame1))
            {
                tiffImage.AddFrame(frame2);
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to generate a multi‑page TIFF archive for scanned invoices, this code lets them add each page as a separate frame, set custom tile sizes, and apply LZW or Adobe Deflate compression to minimize storage while preserving image quality.
 * 2. When building a GIS tool that exports satellite imagery as a tiled TIFF stack, the snippet enables creation of individual frames with specific compression settings, ensuring efficient handling of large raster datasets.
 * 3. When creating a medical imaging pipeline that stores DICOM‑converted slides as a multi‑frame TIFF, developers can use this example to assign per‑frame compression and tile dimensions, maintaining high‑resolution color fidelity for each slice.
 * 4. When preparing print‑ready artwork that consists of multiple layers, a developer can assemble the layers into a tiled TIFF with chosen compression algorithms before converting the file to PDF for lossless printing.
 * 5. When implementing a document‑management system that bundles several scanned pages into a single TIFF file, this code allows C# developers to programmatically add each page as a frame, control tile size for faster rendering, and select the optimal compression per page.
 */