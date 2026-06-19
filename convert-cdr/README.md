# CDR File Conversion with Aspose.Imaging for .NET  

Convert CorelDRAW (CDR) files to popular image and document formats directly from C#. The examples demonstrate CDR to JPG, PNG (with transparency), PDF (vector‑preserving) and other common scenarios using Aspose.Imaging for .NET.

## What's in This Category
- Load a single‑page CDR and export it as a high‑quality JPEG.  
- Convert a CDR page to PNG while preserving transparency.  
- Transform a CDR document into a PDF that retains vector data.  
- Control rasterization options such as DPI, color depth, and background color.  
- Combine CDR rasterization with other Aspose.Imaging features (e.g., image resizing).

## Quick Start  

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Load the first page of a CDR file
using (var image = (CdrImage)Image.Load("sample.cdr"))
{
    // Export to high‑quality JPEG
    var jpegOptions = new JpegOptions { Quality = 100 };
    image.Save("sample.jpg", jpegOptions);
}
```

The snippet above shows the most common operation: opening a CorelDRAW CDR file and saving it as a JPEG image.

## All Examples  

| Example | Description |
|---|---|
| [load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs](./load-a-single-page-cdr-file-and-save-it-as-a-high-quality-jpg-using-c.cs) | Load a single‑page CDR and save it as a high‑quality JPG. |
| [convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs](./convert-a-single-page-cdr-file-to-png-while-preserving-transparency-with-a-c-snippet.cs) | Convert a CDR page to PNG, keeping transparent areas intact. |
| [transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs](./transform-a-single-page-cdr-document-into-a-pdf-embedding-vector-data-via-c-code.cs) | Convert a CDR document to PDF while embedding its original vector data. |

## Requirements  

- **Aspose.Imaging for .NET** – install via NuGet: `dotnet add package Aspose.Imaging`
- **.NET 9.0** or later  

## ↩️ Back to Main README  

[← Return to the repository root README](../README.md)