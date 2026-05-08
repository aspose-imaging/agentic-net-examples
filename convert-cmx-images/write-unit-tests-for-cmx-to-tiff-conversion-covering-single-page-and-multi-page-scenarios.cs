using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class CmxToTiffTests
{
    // Hardcoded input and output paths
    private const string SinglePageInputPath = "TestData/single_page.cmx";
    private const string SinglePageOutputPath = "Output/single_page.tiff";

    private const string MultiPageInputPath = "TestData/multi_page.cmx";
    private const string MultiPageOutputPath = "Output/multi_page.tiff";

    static void Main()
    {
        try
        {
            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(SinglePageOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(MultiPageOutputPath));

            // Run tests
            var tester = new CmxToTiffTests();
            tester.TestSinglePageConversion();
            tester.TestMultiPageConversion();

            Console.WriteLine("All tests completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Test conversion of a single‑page CMX file to TIFF
    public void TestSinglePageConversion()
    {
        // Verify input file exists
        if (!File.Exists(SinglePageInputPath))
        {
            Console.Error.WriteLine($"File not found: {SinglePageInputPath}");
            return;
        }

        // Load the CMX image
        using (Image cmxImage = Image.Load(SinglePageInputPath))
        {
            // Prepare TIFF save options (default format)
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save as TIFF
            cmxImage.Save(SinglePageOutputPath, tiffOptions);
        }

        // Verify output file was created
        if (File.Exists(SinglePageOutputPath))
        {
            Console.WriteLine("Single‑page conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Single‑page conversion failed: output file not found.");
        }
    }

    // Test conversion of a multi‑page CMX file to TIFF (all pages)
    public void TestMultiPageConversion()
    {
        // Verify input file exists
        if (!File.Exists(MultiPageInputPath))
        {
            Console.Error.WriteLine($"File not found: {MultiPageInputPath}");
            return;
        }

        // Load the CMX image
        using (Image cmxImage = Image.Load(MultiPageInputPath))
        {
            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // If the source image supports multipage, export all pages
            if (cmxImage is IMultipageImage multipage && multipage.PageCount > 1)
            {
                // Export all pages (0 to PageCount-1)
                tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Save as TIFF
            cmxImage.Save(MultiPageOutputPath, tiffOptions);
        }

        // Verify output file was created
        if (File.Exists(MultiPageOutputPath))
        {
            Console.WriteLine("Multi‑page conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Multi‑page conversion failed: output file not found.");
        }
    }
}