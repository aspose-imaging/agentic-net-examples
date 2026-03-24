using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicom = (DicomImage)image;

            // Adjust brightness
            dicom.AdjustBrightness(30);

            // Resize (double size) using nearest neighbour resampling
            dicom.Resize(dicom.Width * 2, dicom.Height * 2, ResizeType.NearestNeighbourResample);

            // Configure DICOM save options with JPEG compression and RGB24 color type
            var options = new DicomOptions
            {
                ColorType = ColorType.Rgb24Bit,
                Compression = new Compression
                {
                    Type = CompressionType.Jpeg,
                    Jpeg = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Baseline,
                        SampleRoundingMode = SampleRoundingMode.Truncate,
                        Quality = 70
                    }
                }
            };

            // Save the modified DICOM image
            dicom.Save(outputPath, options);
        }
    }
}