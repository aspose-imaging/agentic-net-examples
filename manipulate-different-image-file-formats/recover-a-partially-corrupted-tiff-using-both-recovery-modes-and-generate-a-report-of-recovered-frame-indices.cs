using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\corrupted.tif";
            string outputPath = "output\\recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                tiff.Save(outputPath);
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
 * 1. When a medical imaging system receives a multi‑page DICOM‑converted TIFF that was truncated during network transfer, a developer can use Aspose.Imaging’s DataRecoveryMode to restore the readable pages and log the indices of recovered frames for audit.
 * 2. When a digital archiving workflow processes scanned historical documents stored as multi‑frame TIFFs and encounters file corruption due to storage media failure, the code can recover intact pages using both ConsistentRecover and FullRecover modes and produce a report of which pages were successfully restored.
 * 3. When a satellite‑imagery processing pipeline ingests large GeoTIFF files that become partially corrupted by power loss, a developer can apply Aspose.Imaging’s recovery options to salvage usable raster bands and generate a list of recovered band indices for downstream analysis.
 * 4. When an e‑commerce platform generates product catalogs as multi‑page TIFFs and a batch job fails, leaving some pages unreadable, the recovery code can rebuild the catalog file and output the indices of the recovered pages to notify content managers.
 * 5. When a printing press receives multi‑layer TIFF artwork files that are damaged during file exchange, a developer can employ both recovery modes to extract the intact layers and create a summary report of recovered layer indices to guide manual re‑creation.
 */