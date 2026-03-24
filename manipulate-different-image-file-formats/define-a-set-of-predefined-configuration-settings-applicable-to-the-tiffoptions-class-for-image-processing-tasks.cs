using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var presets = new Dictionary<string, TiffOptions>();

        var defaultOptions = new TiffOptions(TiffExpectedFormat.Default);
        presets["Default"] = defaultOptions;

        var lzwOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
        lzwOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        lzwOptions.Compression = TiffCompressions.Lzw;
        lzwOptions.Photometric = TiffPhotometrics.Rgb;
        lzwOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        presets["LzwRgb"] = lzwOptions;

        var jpegOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
        jpegOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        jpegOptions.Compression = TiffCompressions.Jpeg;
        jpegOptions.Photometric = TiffPhotometrics.Rgb;
        jpegOptions.YCbCrSubsampling = new ushort[] { 2, 2 };
        jpegOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        presets["JpegYcbcr"] = jpegOptions;

        var ccittOptions = new TiffOptions(TiffExpectedFormat.TiffCcittFax3);
        ccittOptions.BitsPerSample = new ushort[] { 1 };
        ccittOptions.Compression = TiffCompressions.CcittFax3;
        ccittOptions.Photometric = TiffPhotometrics.MinIsBlack;
        ccittOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        presets["CcittFax3Bw"] = ccittOptions;

        var predictorOptions = new TiffOptions(TiffExpectedFormat.Default);
        predictorOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        predictorOptions.ByteOrder = TiffByteOrder.BigEndian;
        predictorOptions.Compression = TiffCompressions.Lzw;
        predictorOptions.Predictor = TiffPredictor.Horizontal;
        predictorOptions.Photometric = TiffPhotometrics.Rgb;
        predictorOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        presets["BigEndianPredictor"] = predictorOptions;

        Console.WriteLine("Defined TiffOptions presets:");
        foreach (var name in presets.Keys)
        {
            Console.WriteLine($"- {name}");
        }
    }
}