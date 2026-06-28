using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class CmxToTiffTests
{
    // Hardcoded input and output paths
    private const string SinglePageInput = @"C:\TestData\single_page.cmx";
    private const string SinglePageOutput = @"C:\TestOutput\single_page.tiff";

    private const string MultiPageInput = @"C:\TestData\multi_page.cmx";
    private const string MultiPageOutput = @"C:\TestOutput\multi_page.tiff";

    static void Main()
    {
        try
        {
            // Run tests
            TestSinglePageConversion();
            TestMultiPageConversion();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void TestSinglePageConversion()
    {
        // Verify input file exists
        if (!File.Exists(SinglePageInput))
        {
            Console.Error.WriteLine($"File not found: {SinglePageInput}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(SinglePageOutput));

        // Load CMX image
        using (Image image = Image.Load(SinglePageInput))
        {
            // Cast to CmxImage for access to specific properties
            CmxImage cmxImage = image as CmxImage;
            if (cmxImage == null)
            {
                Console.Error.WriteLine("Failed to load CMX image.");
                return;
            }

            // Verify it is a single‑page document
            if (cmxImage.PageCount != 1)
            {
                Console.Error.WriteLine($"Expected 1 page, but found {cmxImage.PageCount} pages.");
                return;
            }

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save as TIFF
            cmxImage.Save(SinglePageOutput, tiffOptions);
        }

        // Verify output file was created
        if (File.Exists(SinglePageOutput))
        {
            Console.WriteLine("Single‑page CMX to TIFF conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Single‑page conversion failed: output file not found.");
        }
    }

    private static void TestMultiPageConversion()
    {
        // Verify input file exists
        if (!File.Exists(MultiPageInput))
        {
            Console.Error.WriteLine($"File not found: {MultiPageInput}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(MultiPageOutput));

        // Load CMX image
        using (Image image = Image.Load(MultiPageInput))
        {
            CmxImage cmxImage = image as CmxImage;
            if (cmxImage == null)
            {
                Console.Error.WriteLine("Failed to load CMX image.");
                return;
            }

            // Verify it has multiple pages
            if (cmxImage.PageCount <= 1)
            {
                Console.Error.WriteLine($"Expected multiple pages, but found {cmxImage.PageCount} page(s).");
                return;
            }

            // Prepare TIFF save options with MultiPage support
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            // Export all pages as separate frames in the TIFF
            tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, cmxImage.PageCount));

            // Save as multi‑page TIFF
            cmxImage.Save(MultiPageOutput, tiffOptions);
        }

        // Verify output file was created
        if (File.Exists(MultiPageOutput))
        {
            Console.WriteLine("Multi‑page CMX to TIFF conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Multi‑page conversion failed: output file not found.");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to ensure that a single‑page CorelDRAW CMX file can be reliably converted to a TIFF image for document management systems.
 * 2. When a developer must validate that multi‑page CMX documents are correctly split and saved as multi‑frame TIFF files for batch printing workflows.
 * 3. When a developer wants to automate regression testing to detect breaking changes in the Aspose.Imaging CMX‑to‑TIFF conversion after library upgrades.
 * 4. When a developer is building a file‑conversion service and needs unit tests that confirm the output directory is created and the TIFF file is generated without errors.
 * 5. When a developer requires verification that the loaded CMX image’s page count matches expectations before performing format conversion in a C# image‑processing pipeline.
 */