namespace DaddyRecoveryBuilder.Editors
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using Helpers;

    /// <summary>
    /// <b>VS_VERSIONINFO</b>
    /// <br>This structure depicts the organization of data in a file-version resource. It is the root structure</br>
    /// <br>that contains all other file-version information structures.</br>
    /// <br></br>
    /// <br>Эта структура отображает организацию данных в ресурсе файловой версии. Это корневая структура</br>
    /// <br>который содержит все остальные структуры информации о версиях файла.</br>
    /// <br>http://msdn.microsoft.com/en-us/library/aa914916.aspx</br>
    /// </summary>
    public class AssemblyEditor : Resource
    {
        private FixedFileInfo _fixedfileinfo = new FixedFileInfo();

        /// <summary>
        /// <br>The resource header.</br>
        /// <br>Заголовок ресурса.</br>
        /// </summary>
        public ResourceTableHeader Header { get; } = new ResourceTableHeader("VS_VERSION_INFO");

        /// <summary>
        /// <br>A dictionary of resource tables.</br>
        /// <br>Словарь таблиц ресурсов.</br>
        /// </summary>
        public OrderedDictionary Resources { get; } = new OrderedDictionary();

        /// <summary>
        /// <br>A new language-netural version resource.</br>
        /// <br>Ресурс новой языковой и сетевой версии.</br>
        /// </summary>
        public AssemblyEditor() : base(IntPtr.Zero, IntPtr.Zero, new ResourceId(Enums.ResourceTypes.RT_VERSION), new ResourceId(1), ResourceUtil.USENGLISHLANGID, 0)
        {
            Header.Header = new Structures.RESOURCE_HEADER(_fixedfileinfo.Size);
        }

        /// <summary>
        /// <br>Read a version resource from a previously loaded module.</br>
        /// <br>Прочитать ресурс версии из ранее загруженного модуля.</br>
        /// </summary>
        /// <param name="hModule">Module handle.</param>
        /// <param name="lpRes">Pointer to the beginning of the resource.</param>
        /// <returns><br>Pointer to the end of the resource.</br><br>Указатель на конец ресурса.</br></returns>
        internal override IntPtr Read(IntPtr hModule, IntPtr lpRes)
        {
            Resources.Clear();

            IntPtr pFixedFileInfo = Header.Read(lpRes);

            if (Header.Header.wValueLength != 0)
            {
                _fixedfileinfo = new FixedFileInfo();
                _fixedfileinfo.Read(pFixedFileInfo);
            }

            IntPtr pChild = ResourceUtil.Align(pFixedFileInfo.ToInt64() + Header.Header.wValueLength);

            while (pChild.ToInt64() < (lpRes.ToInt64() + Header.Header.wLength))
            {
                var rc = new ResourceTableHeader(pChild);
                switch (rc?.Key)
                {
                    case "StringFileInfo": { var sr = new StringFileInfo(pChild); rc = sr; } break;
                    default: rc = new VarFileInfo(pChild); break;
                }

                Resources.Add(rc.Key, rc);
                pChild = ResourceUtil.Align(pChild.ToInt64() + rc.Header.wLength);
            }

            return new IntPtr(lpRes.ToInt64() + Header.Header.wLength);
        }

        /// <summary>
        /// <br>String representation of the file version.</br>
        /// <br>Строковое представление версии файла.</br>
        /// </summary>
        public string FileVersion
        {
            get => _fixedfileinfo.FileVersion;
            set => _fixedfileinfo.FileVersion = value;
        }

        /// <summary>
        /// <br>String representation of the protect version.</br>
        /// <br>Строковое представление версии продукта.</br>
        /// </summary>
        public string ProductVersion
        {
            get => _fixedfileinfo.ProductVersion;
            set => _fixedfileinfo.ProductVersion = value;
        }

        /// <summary>
        /// <br>Write this version resource to a binary stream.</br>
        /// <br>Запись этот ресурс версии в двоичный поток.</br>
        /// </summary>
        /// <param name="w"><br>Binary stream.</br><br>Двоичный поток.</br></param>
        internal override void Write(BinaryWriter w)
        {
            long headerPos = w.BaseStream.Position;
            Header.Write(w);

            if (_fixedfileinfo != null)
            {
                _fixedfileinfo.Write(w);
            }

            foreach (DictionaryEntry dictionaryEntry in Resources)
            {
                ((ResourceTableHeader)dictionaryEntry.Value).Write(w);
            }

            ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
        }

        /// <summary>
        /// <br>Returns an entry within this resource table.</br>
        /// <br>Возвращает запись в этой таблице ресурсов.</br>
        /// </summary>
        /// <param name="key"><br>Entry key.</br><br>Ключ входа.</br></param>
        /// <returns><br>A resource table.</br><br>Таблица ресурсов.</br></returns>
        public ResourceTableHeader this[string key]
        {
            get => (ResourceTableHeader)Resources[key];
            set => Resources[key] = value;
        }

        /// <summary>
        /// <br>Returns an entry within this resource table.</br>
        /// <br>Возвращает запись в этой таблице ресурсов.</br>
        /// </summary>
        /// <param name="index"><br>Entry index.</br><br>Индекс входа.</br></param>
        /// <returns><br>A resource table.</br><br>Таблица ресурсов.</br></returns>
        public ResourceTableHeader this[int index]
        {
            get => (ResourceTableHeader)Resources[index];
            set => Resources[index] = value;
        }

        /// <summary>
        /// <br>Return string representation of the version resource.</br>
        /// <br>Вернуть строковое представление ресурса версии.</br>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_fixedfileinfo != null)
            {
                sb.Append(_fixedfileinfo?.ToString());
            }
            sb.AppendLine("BEGIN");
            foreach (DictionaryEntry dictionaryEntry in Resources)
            {
                sb.Append(((ResourceTableHeader)dictionaryEntry.Value)?.ToString(1));
            }
            sb.AppendLine("END");
            return sb?.ToString();
        }
    }
    /// <summary>
    /// <br>A device-independent image consists of a BITMAPINFOHEADER where</br>
    /// <br>bmWidth is the width of the image andbmHeight is double the height</br>
    /// <br>of the image, followed by the bitmap color table, followed by the image</br>
    /// <br>pixels, followed by the mask pixels.</br>
    /// </summary>
    public class DeviceIndependentBitmap
    {
        private Structures.BITMAPINFOHEADER _header = new Structures.BITMAPINFOHEADER();
        private byte[] _data = null;
        private Bitmap _mask = null, _color = null, _image = null;

        /// <summary>
        /// <br>Raw image data.</br>
        /// <br>Необработанные данные изображения.</br>
        /// </summary>
        public byte[] Data
        {
            get => _data;
            set
            {
                _data = value;

                IntPtr pData = Marshal.AllocHGlobal(Marshal.SizeOf(_header));
                try
                {
                    Marshal.Copy(_data, 0, pData, Marshal.SizeOf(_header));
                    _header = (Structures.BITMAPINFOHEADER)Marshal.PtrToStructure(pData, typeof(Structures.BITMAPINFOHEADER));
                }
                finally
                {
                    Marshal.FreeHGlobal(pData);
                }
            }
        }

        /// <summary>
        /// <br>Bitmap info header.</br>
        /// <br>Заголовок информации о растровом изображении.</br>
        /// </summary>
        public Structures.BITMAPINFOHEADER Header => _header;

        /// <summary>
        /// <br>Bitmap size in bytes.</br>
        /// <br>Размер растрового изображения в байтах.</br>
        /// </summary>
        public int Size => _data.Length;

        /// <summary>
        /// <br>Create a copy of an image.</br>
        /// <br>Создание копии изображения.</br>
        /// </summary>
        /// <param name="image"><br>Source image.</br><br>Исходное изображение.</br></param>
        public DeviceIndependentBitmap(DeviceIndependentBitmap image)
        {
            _data = new byte[image._data.Length];
            Buffer.BlockCopy(image._data, 0, _data, 0, image._data.Length);
            _header = image._header;
        }

        /// <summary>
        /// <br>Size of the image mask.</br>
        /// <br>Размер маски изображения.</br>
        /// </summary>
        private int MaskImageSize => _header.Height / 2 * GetDIBRowWidth(_header.Width);
        private int XorImageSize => _header.Height / 2 * GetDIBRowWidth(_header.Width * _header.BitCount * _header.Planes);

        /// <summary>
        /// <br>Position of the DIB bitmap bits within a DIB bitmap array.</br>
        /// <br>Положение битов битовой карты DIB в массиве битовой карты DIB.</br>
        /// </summary>
        private int XorImageIndex => (int)(Marshal.SizeOf(_header) + (ColorCount * Marshal.SizeOf(new Structures.RGBQUAD())));

        /// <summary>
        /// <br>Number of colors in the palette.</br>
        /// <br>Количество цветов в палитре.</br>
        /// </summary>
        private uint ColorCount => _header.ClrUsed != 0 ? _header.ClrUsed : _header.BitCount <= 8 ? (uint)(1 << _header.BitCount) : 0;
        private int MaskImageIndex => XorImageIndex + XorImageSize;

        /// <summary>
        /// <br>Returns the width of a row in a DIB Bitmap given the number of bits.</br>
        /// <br>DIB Bitmap rows always align on a DWORD boundary.</br>
        /// <br></br>
        /// <br>Возвращает ширину строки в битовой карте DIB с учетом количества бит.</br>
        /// <br>Строки растрового изображения DIB всегда выравниваются по границе DWORD.</br>
        /// </summary>
        /// <param name="width">Number of bits.</param>
        /// <returns><br>Width of a row in bytes.</br><br>Ширина строки в байтах.</br></returns>
        private int GetDIBRowWidth(int width) => (width + 31) / 32 * 4;

        /// <summary>
        /// <br>Bitmap monochrome mask.</br>
        /// <br>Растровая монохромная маска.</br>
        /// </summary>
        public Bitmap Mask
        {
            get
            {
                if (_mask != null) { return _mask; }
                IntPtr hdc = IntPtr.Zero, hBmpOld = IntPtr.Zero, bitsInfo = IntPtr.Zero, bits = IntPtr.Zero;

                try
                {
                    // extract monochrome mask
                    // извлечь монохромную маску
                    hdc = NativeMethods.CreateCompatibleDC(IntPtr.Zero);
                    if (hdc == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    IntPtr hBmp = NativeMethods.CreateCompatibleBitmap(hdc, _header.Width, _header.Height / 2);
                    if (hBmp == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    hBmpOld = NativeMethods.SelectObject(hdc, hBmp);

                    // prepare BitmapInfoHeader for mono bitmap:
                    // подготовить BitmapInfoHeader для моно растрового изображения:
                    int monoBmHdrSize = (int)_header.Size + (Marshal.SizeOf(new Structures.RGBQUAD()) * 2);

                    bitsInfo = Marshal.AllocCoTaskMem(monoBmHdrSize);
                    Marshal.WriteInt32(bitsInfo, Marshal.SizeOf(_header));
                    Marshal.WriteInt32(bitsInfo, 4, _header.Width);
                    Marshal.WriteInt32(bitsInfo, 8, _header.Height / 2);
                    Marshal.WriteInt16(bitsInfo, 12, 1);
                    Marshal.WriteInt16(bitsInfo, 14, 1);
                    Marshal.WriteInt32(bitsInfo, 16, (int)Enums.BitmapCompression.BI_RGB);
                    Marshal.WriteInt32(bitsInfo, 20, 0);
                    Marshal.WriteInt32(bitsInfo, 24, 0);
                    Marshal.WriteInt32(bitsInfo, 28, 0);
                    Marshal.WriteInt32(bitsInfo, 32, 0);
                    Marshal.WriteInt32(bitsInfo, 36, 0);
                    // black and white color indices
                    // индексы черного и белого цвета
                    Marshal.WriteInt32(bitsInfo, 40, 0);
                    Marshal.WriteByte(bitsInfo, 44, 255);
                    Marshal.WriteByte(bitsInfo, 45, 255);
                    Marshal.WriteByte(bitsInfo, 46, 255);
                    Marshal.WriteByte(bitsInfo, 47, 0);
                    // prepare mask bits
                    // подготовить биты маски
                    bits = Marshal.AllocCoTaskMem(MaskImageSize);
                    Marshal.Copy(_data, MaskImageIndex, bits, MaskImageSize);

                    if (0 == NativeMethods.SetDIBitsToDevice(hdc, 0, 0, (uint)_header.Width, (uint)_header.Height / 2, 0, 0, 0, (uint)_header.Height / 2, bits, bitsInfo, (uint)Enums.DIBColors.DIB_RGB_COLORS))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    _mask = System.Drawing.Image.FromHbitmap(hBmp);
                }
                finally
                {
                    if (bits != IntPtr.Zero) { Marshal.FreeCoTaskMem(bits); }
                    if (bitsInfo != IntPtr.Zero) { Marshal.FreeCoTaskMem(bitsInfo); }
                    if (hdc != IntPtr.Zero) { NativeMethods.SelectObject(hdc, hBmpOld); }
                    if (hdc != IntPtr.Zero) { NativeMethods.DeleteObject(hdc); }
                }

                return _mask;
            }
        }

        /// <summary>
        /// <br>Bitmap color (XOR) part of the image.</br>
        /// <br>Растровая цветная (XOR) часть изображения.</br>
        /// </summary>
        public Bitmap Color
        {
            get
            {
                if (_color != null) { return _color; }

                IntPtr hdc = IntPtr.Zero, hdcDesktop = IntPtr.Zero, hBmpOld = IntPtr.Zero, bitsInfo = IntPtr.Zero, bits = IntPtr.Zero;

                try
                {
                    hdcDesktop = NativeMethods.GetDC(IntPtr.Zero); // NativeMethods.CreateDC("DISPLAY", null, null, IntPtr.Zero);
                    if (hdcDesktop == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    hdc = NativeMethods.CreateCompatibleDC(hdcDesktop);
                    if (hdc == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    IntPtr hBmp = NativeMethods.CreateCompatibleBitmap(hdcDesktop, _header.Width, _header.Height / 2);
                    if (hBmp == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    hBmpOld = NativeMethods.SelectObject(hdc, hBmp);

                    // bitmap header
                    // заголовок изображения
                    bitsInfo = Marshal.AllocCoTaskMem(XorImageIndex);
                    if (bitsInfo == null)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    Marshal.Copy(_data, 0, bitsInfo, XorImageIndex);
                    // fix the height
                    // зафиксировать высоту
                    Marshal.WriteInt32(bitsInfo, 8, _header.Height / 2);
                    // XOR bits
                    bits = Marshal.AllocCoTaskMem(XorImageSize);
                    Marshal.Copy(_data, XorImageIndex, bits, XorImageSize);

                    if (0 == NativeMethods.SetDIBitsToDevice(hdc, 0, 0, (uint)_header.Width, (uint)_header.Height / 2, 0, 0, 0, (uint)(_header.Height / 2), bits, bitsInfo, (int)Enums.DIBColors.DIB_RGB_COLORS))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    _color = System.Drawing.Image.FromHbitmap(hBmp);
                }
                finally
                {
                    if (hdcDesktop != IntPtr.Zero) { NativeMethods.DeleteDC(hdcDesktop); }
                    if (bits != IntPtr.Zero) { Marshal.FreeCoTaskMem(bits); }
                    if (bitsInfo != IntPtr.Zero) { Marshal.FreeCoTaskMem(bitsInfo); }
                    if (hdc != IntPtr.Zero) { NativeMethods.SelectObject(hdc, hBmpOld); }
                    if (hdc != IntPtr.Zero) { NativeMethods.DeleteObject(hdc); }
                }

                return _color;
            }
        }

        /// <summary>
        /// <br>Complete image.</br>
        /// <br>Полное изображение.</br>
        /// </summary>
        public Bitmap Image
        {
            get
            {
                if (_image != null) { return _image; }

                IntPtr hDCScreen = IntPtr.Zero, hDCScreenOUTBmp = IntPtr.Zero, hBitmapOUTBmp = IntPtr.Zero;

                try
                {
                    hDCScreen = NativeMethods.GetDC(IntPtr.Zero);
                    if (hDCScreen == IntPtr.Zero)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    // Image
                    // Изображение
                    var bitmapInfo = new Structures.BITMAPINFO
                    {
                        bmiHeader = _header
                    };
                    // bitmapInfo.bmiColors = Tools.StandarizePalette(mEncoder.Colors);
                    hDCScreenOUTBmp = NativeMethods.CreateCompatibleDC(hDCScreen);
                    hBitmapOUTBmp = NativeMethods.CreateDIBSection(hDCScreenOUTBmp, ref bitmapInfo, 0, out IntPtr bits, IntPtr.Zero, 0);
                    Marshal.Copy(_data, XorImageIndex, bits, XorImageSize);
                    _image = System.Drawing.Image.FromHbitmap(hBitmapOUTBmp);
                }
                finally
                {
                    if (hDCScreen != IntPtr.Zero) { NativeMethods.ReleaseDC(IntPtr.Zero, hDCScreen); }
                    if (hBitmapOUTBmp != IntPtr.Zero) { NativeMethods.DeleteObject(hBitmapOUTBmp); }
                    if (hDCScreenOUTBmp != IntPtr.Zero) { NativeMethods.DeleteDC(hDCScreenOUTBmp); }
                }

                return _image;
            }
        }
    }
    /// <summary>
    /// Fixed file information.
    /// </summary>
    public class FixedFileInfo
    {
        Structures.VS_FIXEDFILEINFO _fixedfileinfo = Structures.VS_FIXEDFILEINFO.GetWindowsDefault();

        /// <summary>
        /// <br>Default Windows fixed file information.</br>
        /// <br>Информация о фиксированных файлах Windows по умолчанию.</br>
        /// </summary>
        public FixedFileInfo() { }

        /// <summary>
        /// <br>Fixed file info structure.</br>
        /// <br>Фиксированная структура информации о файлах.</br>
        /// </summary>
        public Structures.VS_FIXEDFILEINFO Value => _fixedfileinfo;

        /// <summary>
        /// <br>Read the fixed file information structure.</br>
        /// <br>Прочтитать фиксированную информационную структуру файла.</br>
        /// </summary>
        /// <param name="lpRes"><br>Address in memory.</br><br>Адрес в памяти.</br></param>
        internal void Read(IntPtr lpRes)
        {
            _fixedfileinfo = (Structures.VS_FIXEDFILEINFO)Marshal.PtrToStructure(lpRes, typeof(Structures.VS_FIXEDFILEINFO));
        }

        /// <summary>
        /// <br>String representation of the file version.</br>
        /// <br>Версия файла</br>
        /// </summary>
        public string FileVersion
        {
            get => $"{ResourceUtil.HiWord(_fixedfileinfo.dwFileVersionMS)}.{ResourceUtil.LoWord(_fixedfileinfo.dwFileVersionMS)}.{ResourceUtil.HiWord(_fixedfileinfo.dwFileVersionLS)}.{ResourceUtil.LoWord(_fixedfileinfo.dwFileVersionLS)}";
            set
            {
                uint major = 0, minor = 0, InfoViewer = 0, release = 0;
                string[] version_s = value.Split(".".ToCharArray(), 4);
                if (version_s.Length >= 1)
                {
                    major = uint.Parse(version_s[0]);
                }

                if (version_s.Length >= 2)
                {
                    minor = uint.Parse(version_s[1]);
                }

                if (version_s.Length >= 3)
                {
                    InfoViewer = uint.Parse(version_s[2]);
                }

                if (version_s.Length >= 4)
                {
                    release = uint.Parse(version_s[3]);
                }

                _fixedfileinfo.dwFileVersionMS = (major << 16) + minor;
                _fixedfileinfo.dwFileVersionLS = (InfoViewer << 16) + release;
            }
        }

        /// <summary>
        /// <br>String representation of the protect version.</br>
        /// <br>Версия продукта</br>
        /// </summary>
        public string ProductVersion
        {
            get => $"{ResourceUtil.HiWord(_fixedfileinfo.dwProductVersionMS)}.{ResourceUtil.LoWord(_fixedfileinfo.dwProductVersionMS)}.{ResourceUtil.HiWord(_fixedfileinfo.dwProductVersionLS)}.{ResourceUtil.LoWord(_fixedfileinfo.dwProductVersionLS)}";
            set
            {
                uint major = 0, minor = 0, InfoViewer = 0, release = 0;
                string[] version_s = value.Split(".".ToCharArray(), 4);
                if (version_s.Length >= 1)
                {
                    major = uint.Parse(version_s[0]);
                }

                if (version_s.Length >= 2)
                {
                    minor = uint.Parse(version_s[1]);
                }

                if (version_s.Length >= 3)
                {
                    InfoViewer = uint.Parse(version_s[2]);
                }

                if (version_s.Length >= 4)
                {
                    release = uint.Parse(version_s[3]);
                }

                _fixedfileinfo.dwProductVersionMS = (major << 16) + minor;
                _fixedfileinfo.dwProductVersionLS = (InfoViewer << 16) + release;
            }
        }

        /// <summary>
        /// <br>Gets or sets a bitmask that specifies the Boolean attributes of the file.</br>
        /// <br>Получает или задает битовую маску, определяющую логические атрибуты файла.</br>
        /// </summary>
        public uint FileFlags
        {
            get => _fixedfileinfo.dwFileFlags;
            set => _fixedfileinfo.dwFileFlags = value;
        }

        /// <summary>
        /// <br>Write fixed file information to a binary stream.</br>
        /// <br>Записать фиксированную информацию о файле в двоичный поток.</br>
        /// </summary>
        /// <param name="w"><br>Binary stream.</br><br>Двоичный поток.</br></param>
        public void Write(BinaryWriter w)
        {
            w.Write(ResourceUtil.GetBytes(_fixedfileinfo));
            ResourceUtil.PadToDWORD(w);
        }

        /// <summary>
        /// <br>Size of the VS_FIXEDFILEINFO structure.</br>
        /// <br>Размер структуры VS_FIXEDFILEINFO.</br>
        /// </summary>
        public ushort Size => (ushort)Marshal.SizeOf(_fixedfileinfo);

        /// <summary>
        /// <br>String representation of the fixed file info.</br>
        /// <br>Строковое представление фиксированной информации о файле.</br>
        /// </summary>
        /// <returns><br>String representation of the fixed file info.</br><br>Строковое представление фиксированной информации о файле.</br></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"FILEVERSION {ResourceUtil.HiWord(_fixedfileinfo.dwFileVersionMS)},{ResourceUtil.LoWord(_fixedfileinfo.dwFileVersionMS)},{ResourceUtil.HiWord(_fixedfileinfo.dwFileVersionLS)},{ResourceUtil.LoWord(_fixedfileinfo.dwFileVersionLS)}");
            sb.AppendLine($"PRODUCTVERSION {ResourceUtil.HiWord(_fixedfileinfo.dwProductVersionMS)},{ResourceUtil.LoWord(_fixedfileinfo.dwProductVersionMS)},{ResourceUtil.HiWord(_fixedfileinfo.dwProductVersionLS)},{ResourceUtil.LoWord(_fixedfileinfo.dwProductVersionLS)}");
            switch (_fixedfileinfo.dwFileFlagsMask)
            {
                case NativeMethods.VS_FFI_FILEFLAGSMASK: sb.AppendLine("FILEFLAGSMASK VS_FFI_FILEFLAGSMASK"); break;
                default: sb.AppendLine($"FILEFLAGSMASK 0x{_fixedfileinfo.dwFileFlagsMask.ToString():x}"); break;
            }
            sb.AppendLine($"FILEFLAGS {(_fixedfileinfo.dwFileFlags == 0 ? "0" : ResourceUtil.FlagsToString<Enums.FileFlags>(_fixedfileinfo.dwFileFlags))}");
            sb.AppendLine($"FILEOS {ResourceUtil.FlagsToString<Enums.FileOs>(_fixedfileinfo.dwFileFlags)}");
            sb.AppendLine($"FILETYPE {ResourceUtil.FlagsToString<Enums.FileType>(_fixedfileinfo.dwFileType)}");
            sb.AppendLine($"FILESUBTYPE {ResourceUtil.FlagsToString<Enums.FileSubType>(_fixedfileinfo.dwFileSubtype)}");
            return sb?.ToString();
        }
    }
    /// <summary>
    /// <br>A version resource.</br>
    /// <br>Ресурс версии.</br>
    /// </summary>
    public abstract class Resource
    {
        /// <summary>
        /// <br>Resource type.</br>
        /// <br>Тип ресурса</br>
        /// </summary>
        protected ResourceId _type;
        /// <summary>
        /// <br>Resource name.</br>
        /// <br>Имя ресурса</br>
        /// </summary>
        protected ResourceId _name;
        /// <summary>
        /// <br>Resource language.</br>
        /// <br>Язык ресурса</br>
        /// </summary>
        protected ushort _language;
        /// <summary>
        /// <br>Loaded binary nodule.</br>
        /// <br>Загрузка бинарного модуля</br>
        /// </summary>
        protected IntPtr _hModule = IntPtr.Zero;
        /// <summary>
        /// <br>Pointer to the resource.</br>
        /// <br>Указатель на ресурс.</br>
        /// </summary>
        protected IntPtr _hResource = IntPtr.Zero;
        /// <summary>
        /// <br>Resource size.</br>
        /// <br>Размер ресурса</br>
        /// </summary>
        protected int _size = 0;
        /// <summary>
        /// <br>Version resource size in bytes.</br>
        /// <br>Размер ресурса версии в байтах.</br>
        /// </summary>
        public int Size => _size;
        /// <summary>
        /// <br>Language ID.</br>
        /// <br>Идентификатор языка.</br>
        /// </summary>
        public ushort Language
        {
            get => _language;
            set => _language = value;
        }
        /// <summary>
        /// <br>Resource type.</br>
        /// <br>Тип ресурса.</br>
        /// </summary>
        public ResourceId Type => _type;
        /// <summary>
        /// <br>String representation of the resource type.</br>
        /// <br>Строковое представление типа ресурса.</br>
        /// </summary>
        public string TypeName => _type.TypeName;
        /// <summary>
        /// <br>Resource name.</br>
        /// <br>Название ресурса.</br>
        /// </summary>
        public ResourceId Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// <br>A new resource.</br>
        /// <br>Новый ресурс.</br>
        /// </summary>
        internal Resource() { }

        /// <summary>
        /// <br>A structured resource embedded in an executable module.</br>
        /// <br>Структурированный ресурс, встроенный в исполняемый модуль.</br>
        /// </summary>
        /// <param name="hModule">Module handle.</param>
        /// <param name="hResource">Resource handle.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="language">Language ID.</param>
        /// <param name="size">Resource size.</param>
        internal Resource(IntPtr hModule, IntPtr hResource, ResourceId type, ResourceId name, ushort language, int size)
        {
            _hModule = hModule;
            _type = type;
            _name = name;
            _language = language;
            _hResource = hResource;
            _size = size;

            LockAndReadResource(hModule, hResource);
        }

        /// <summary>
        /// <br>Lock and read the resource.</br>
        /// <br>Заблокировать и прочитать ресурс</br>
        /// </summary>
        /// <param name="hModule">Module handle.</param>
        /// <param name="hResource">Resource handle.</param>
        internal void LockAndReadResource(IntPtr hModule, IntPtr hResource)
        {
            if (hResource != IntPtr.Zero)
            {
                IntPtr lpRes = NativeMethods.LockResource(hResource);

                if (lpRes == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                Read(hModule, lpRes);
            }
        }

        /// <summary>
        /// <br>Load a resource from an executable (.exe or .dll) file.</br>
        /// <br>Загрузить ресурс из исполняемого файла (.exe или .dll).</br>
        /// </summary>
        /// <param name="filename"><br>An executable (.exe or .dll) file.</br><br>Исполняемый файл (.exe или .dll)</br></param>
        public virtual void LoadFrom(string filename)
        {
            LoadFrom(filename, _type, _name, _language);
        }

        /// <summary>
        /// <br>Load a resource from an executable (.exe or .dll) file.</br>
        /// <br>Загрузить ресурс из исполняемого файла (.exe или .dll).</br>
        /// </summary>
        /// <param name="filename">An executable (.exe or .dll) file.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="lang">Resource language.</param>
        internal void LoadFrom(string filename, ResourceId type, ResourceId name, ushort lang)
        {
            IntPtr hModule = IntPtr.Zero;

            try
            {
                hModule = NativeMethods.LoadLibraryEx(filename, IntPtr.Zero, NativeMethods.DONT_RESOLVE_DLL_REFERENCES | NativeMethods.LOAD_LIBRARY_AS_DATAFILE);
                LoadFrom(hModule, type, name, lang);
            }
            finally
            {
                if (hModule != IntPtr.Zero)
                {
                    NativeMethods.FreeLibrary(hModule);
                }
            }
        }

        /// <summary>
        /// <br>Load a resource from an executable (.exe or .dll) module.</br>
        /// <br>Загрузить ресурс из исполняемого модуля (.exe или .dll).</br>
        /// </summary>
        /// <param name="hModule"><br>An executable (.exe or .dll) module.</br><br>Исполняемый модуль (.exe или .dll).</br></param>
        /// <param name="type"><br>Resource type.</br><br>Тип ресурса</br></param>
        /// <param name="name"><br>Resource name.</br><br>Имя ресурса</br></param>
        /// <param name="lang"><br>Resource language.</br><br>Язык ресурса</br></param>
        internal void LoadFrom(IntPtr hModule, ResourceId type, ResourceId name, ushort lang)
        {
            if (IntPtr.Zero == hModule)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr hRes = NativeMethods.FindResourceEx(hModule, type.Id, name.Id, lang);
            if (IntPtr.Zero == hRes)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr hGlobal = NativeMethods.LoadResource(hModule, hRes);
            if (IntPtr.Zero == hGlobal)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr lpRes = NativeMethods.LockResource(hGlobal);

            if (lpRes == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            _size = NativeMethods.SizeofResource(hModule, hRes);
            if (_size <= 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            _type = type;
            _name = name;
            _language = lang;

            Read(hModule, lpRes);
        }

        /// <summary>
        /// <br>Read a resource from a previously loaded module.</br>
        /// <br>Прочтитать ресурс из ранее загруженного модуля.</br>
        /// </summary>
        /// <param name="hModule">Module handle.</param>
        /// <param name="lpRes">Pointer to the beginning of the resource.</param>
        /// <returns>Pointer to the end of the resource.</returns>
        internal abstract IntPtr Read(IntPtr hModule, IntPtr lpRes);

        /// <summary>
        /// Write the resource to a memory stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        internal abstract void Write(BinaryWriter w);

        /// <summary>
        /// Return resource data.
        /// </summary>
        /// <returns>Resource data.</returns>
        public byte[] WriteAndGetBytes()
        {
            using var ms = new MemoryStream();
            using var w = new BinaryWriter(ms, Encoding.Default);
            Write(w);
            w.Close();
            return ms?.ToArray();
        }

        /// <summary>
        /// Save a resource.
        /// </summary>
        /// <param name="filename">Name of an executable file (.exe or .dll).</param>
        public virtual void SaveTo(string filename)
        {
            SaveTo(filename, _type, _name, _language);
        }

        /// <summary>
        /// Save a resource to an executable (.exe or .dll) file.
        /// </summary>
        /// <param name="filename">Path to an executable file.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="langid">Language id.</param>
        internal void SaveTo(string filename, ResourceId type, ResourceId name, ushort langid)
        {
            byte[] data = WriteAndGetBytes();
            SaveTo(filename, type, name, langid, data);
        }

        /// <summary>
        /// <br>Save a resource to an executable (.exe or .dll) file.</br>
        /// <br>Сохранить ресурс в исполняемый файл (.exe или .dll).</br>
        /// </summary>
        /// <param name="filename">Path to an executable file.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="lang">Resource language.</param>
        /// <param name="data">Resource data.</param>
        internal static void SaveTo(string filename, ResourceId type, ResourceId name, ushort lang, byte[] data)
        {
            IntPtr h = NativeMethods.BeginUpdateResource(filename, false);

            if (h == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            try
            {
                if (data != null && data.Length == 0)
                {
                    data = null;
                }
                if (!NativeMethods.UpdateResource(h, type.Id, name.Id, lang, data, data == null ? 0 : (uint)data.Length))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch
            {
                NativeMethods.EndUpdateResource(h, true);
                throw;
            }

            if (!NativeMethods.EndUpdateResource(h, false))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
    /// <summary>
    /// <br> ~ Идентификатор ресурса ~</br>
    /// <br>Существует два типа идентификаторов ресурсов: зарезервированные целые числа (например, RT_ICON) и пользовательские строковые имена (например, «CUSTOM»).</br>
    /// </summary>
    public class ResourceId
    {
        private IntPtr _name = IntPtr.Zero;

        /// <summary>
        /// A resource identifier.
        /// </summary>
        /// <param name="value">A integer or string resource id.</param>
        public ResourceId(IntPtr value) => Id = value;

        /// <summary>
        /// A resource identifier.
        /// </summary>
        /// <param name="value">A integer resource id.</param>
        public ResourceId(uint value) => Id = new IntPtr(value);

        /// <summary>
        /// A well-known resource-type identifier.
        /// </summary>
        /// <param name="value">A well known resource type.</param>
        public ResourceId(Enums.ResourceTypes value) => Id = (IntPtr)value;

        /// <summary>
        /// Resource Id.
        /// </summary>
        /// <remarks>
        /// If the resource Id is a string, it will be copied.
        /// </remarks>
        public IntPtr Id
        {
            get => _name;
            set => _name = IsIntResource(value) ? value : Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(value));
        }

        /// <summary>
        /// String representation of a resource type name.
        /// </summary>
        public string TypeName => IsIntResource() ? ResourceType.ToString() : Name;

        /// <summary>
        /// An enumerated resource type for built-in resource types only.
        /// </summary>
        public Enums.ResourceTypes ResourceType
        {
            get => IsIntResource() ? (Enums.ResourceTypes)_name : throw new InvalidCastException($"Resource {Name} is not of built-in type.");
            set => _name = (IntPtr)value;
        }

        /// <summary>
        /// Returns true if the resource is an integer resource.
        /// </summary>
        public bool IsIntResource() => IsIntResource(_name);

        /// <summary>
        /// Returns true if the resource is an integer resource.
        /// </summary>
        /// <param name="value">Resource pointer.</param>
        internal static bool IsIntResource(IntPtr value) => value.ToInt64() <= ushort.MaxValue;

        /// <summary>
        /// Resource Id in a string format.
        /// </summary>
        public string Name
        {
            get => IsIntResource() ? _name.ToString() : Marshal.PtrToStringUni(_name);
            set => _name = Marshal.StringToHGlobalUni(value);
        }

        /// <summary>
        /// String representation of the resource Id.
        /// </summary>
        /// <returns>Resource name.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Resource Id hash code. 
        /// Resource Ids of the same type have the same hash code.
        /// </summary>
        /// <returns>Resource Id.</returns>
        public override int GetHashCode() => IsIntResource() ? Id.ToInt32() : Name.GetHashCode();

        /// <summary>
        /// Compares two resource Ids by value.
        /// </summary>
        /// <param name="obj">Resource Id.</param>
        /// <returns>True if both resource Ids represent the same resource.</returns>
        public override bool Equals(object obj) => (obj is ResourceId && obj == this) || (obj is ResourceId && (obj as ResourceId).GetHashCode() == GetHashCode());
    }
    /// <summary>
    /// A resource table header.
    /// </summary>
    public class ResourceTableHeader
    {
        /// <summary>
        /// Resource table header.
        /// </summary>
        protected Structures.RESOURCE_HEADER _header;

        /// <summary>
        /// Resource table key.
        /// </summary>
        protected string _key;

        /// <summary>
        /// Resource table key.
        /// </summary>
        public string Key => _key;

        /// <summary>
        /// Resource header.
        /// </summary>
        public Structures.RESOURCE_HEADER Header
        {
            get => _header;
            set => _header = value;
        }

        /// <summary>
        /// A new resource table header.
        /// </summary>
        public ResourceTableHeader() { }

        /// <summary>
        /// An resource table header with a specific key.
        /// </summary>
        /// <param name="key">resource key</param>
        public ResourceTableHeader(string key)
        {
            _key = key;
        }

        /// <summary>
        /// An existing resource table.
        /// </summary>
        /// <param name="lpRes">Pointer to resource table data.</param>
        internal ResourceTableHeader(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read the resource header, return a pointer to the end of it.
        /// </summary>
        /// <param name="lpRes">Top of header.</param>
        /// <returns>End of header, after the key, aligned at a 32 bit boundary.</returns>
        internal virtual IntPtr Read(IntPtr lpRes)
        {
            _header = (Structures.RESOURCE_HEADER)Marshal.PtrToStructure(lpRes, typeof(Structures.RESOURCE_HEADER));

            IntPtr pBlockKey = new IntPtr(lpRes.ToInt64() + Marshal.SizeOf(_header));
            _key = Marshal.PtrToStringUni(pBlockKey);

            return ResourceUtil.Align(pBlockKey.ToInt64() + ((_key.Length + 1) * Marshal.SystemDefaultCharSize));
        }

        /// <summary>
        /// Write the resource table.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        internal virtual void Write(BinaryWriter w)
        {
            // wLength
            w.Write(_header.wLength);
            // wValueLength
            w.Write(_header.wValueLength);
            // wType
            w.Write(_header.wType);
            // write key
            w.Write(Encoding.Unicode.GetBytes(_key));
            // null-terminator
            w.Write((ushort)0);
            // pad fixed info
            ResourceUtil.PadToDWORD(w);
        }

        /// <summary>
        /// String representation.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString() => ToString(0);

        /// <summary>
        /// String representation.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String representation.</returns>
        public virtual string ToString(int indent) => base.ToString();
    }
    /// <summary>
    /// Resource utilities.
    /// </summary>
    public static class ResourceUtil
    {
        /// <summary>
        /// Align an address to a 4-byte boundary.
        /// </summary>
        /// <param name="p">Address in memory.</param>
        /// <returns>4-byte aligned pointer.</returns>
        internal static IntPtr Align(long p) => new IntPtr((p + 3) & ~3);

        /// <summary>
        /// Align a pointer to a 4-byte boundary.
        /// </summary>
        /// <param name="p">Pointer to an address in memory.</param>
        /// <returns>4-byte aligned pointer.</returns>
        internal static IntPtr Align(IntPtr p) => Align(p.ToInt64());

        /// <summary>
        /// Pad data to a WORD.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <returns>New position within the binary stream.</returns>
        internal static long PadToWORD(BinaryWriter w)
        {
            long pos = w.BaseStream.Position;

            if (pos % 2 != 0)
            {
                long count = 2 - (pos % 2);
                Pad(w, (ushort)count);
                pos += count;
            }

            return pos;
        }

        /// <summary>
        /// Pad data to a DWORD.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <returns>New position within the binary stream.</returns>
        internal static long PadToDWORD(BinaryWriter w)
        {
            long pos = w.BaseStream.Position;

            if (pos % 4 != 0)
            {
                long count = 4 - (pos % 4);
                Pad(w, (ushort)count);
                pos += count;
            }

            return pos;
        }

        /// <summary>
        /// Returns the high WORD from a DWORD value.
        /// </summary>
        /// <param name="value">WORD value.</param>
        /// <returns>High WORD.</returns>
        internal static ushort HiWord(uint value) => (ushort)((value & 0xFFFF0000) >> 16);

        /// <summary>
        /// Returns the high WORD from a DWORD value.
        /// </summary>
        /// <param name="value">WORD value.</param>
        /// <returns>High WORD.</returns>
        internal static ushort LoWord(uint value) => (ushort)(value & 0x0000FFFF);

        /// <summary>
        /// Write a value at a given position.
        /// Used to write a size of data in an earlier located header.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="address">Address to write the value at.</param>
        internal static void WriteAt(BinaryWriter w, long value, long address)
        {
            long cur = w.BaseStream.Position;
            w.Seek((int)address, SeekOrigin.Begin);
            w.Write((ushort)value);
            w.Seek((int)cur, SeekOrigin.Begin);
        }

        /// <summary>
        /// Pad bytes.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <param name="len">Number of bytes to write.</param>
        /// <returns>New position within the stream.</returns>
        internal static long Pad(BinaryWriter w, ushort len)
        {
            while (len-- > 0)
            {
                w.Write((byte)0);
            }

            return w.BaseStream.Position;
        }

        /// <summary>
        /// Neutral language ID.
        /// </summary>
        public static ushort NEUTRALLANGID => MAKELANGID(NativeMethods.LANG_NEUTRAL, NativeMethods.SUBLANG_NEUTRAL);

        /// <summary>
        /// US-English language ID.
        /// </summary>
        public static ushort USENGLISHLANGID => MAKELANGID(NativeMethods.LANG_ENGLISH, NativeMethods.SUBLANG_ENGLISH_US);

        /// <summary>
        /// Make a language ID from a primary language ID (low-order 10 bits) and a sublanguage (high-order 6 bits).
        /// </summary>
        /// <param name="primary">Primary language ID.</param>
        /// <param name="sub">Sublanguage ID.</param>
        /// <returns>Microsoft language ID.</returns>
        public static ushort MAKELANGID(int primary, int sub) => (ushort)((((ushort)sub) << 10) | ((ushort)primary));

        /// <summary>
        /// Return the primary language ID from a Microsoft language ID.
        /// </summary>
        /// <param name="lcid">Microsoft language ID</param>
        /// <returns>primary language ID (low-order 10 bits)</returns>
        public static ushort PRIMARYLANGID(ushort lcid) => (ushort)(lcid & 0x3ff);

        /// <summary>
        /// Return the sublanguage ID from a Microsoft language ID.
        /// </summary>
        /// <param name="lcid">Microsoft language ID.</param>
        /// <returns>Sublanguage ID (high-order 6 bits).</returns>
        public static ushort SUBLANGID(ushort lcid) => (ushort)(lcid >> 10);

        /// <summary>
        /// Returns the memory representation of an object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="anything">Data.</param>
        /// <returns>Object's representation in memory.</returns>
        internal static byte[] GetBytes<T>(T anything)
        {
            int rawsize = Marshal.SizeOf(anything);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(anything, buffer, false);
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
        }

        /// <summary>
        /// Get a collection of flags from a flag value.
        /// </summary>
        /// <typeparam name="T">Flag collection type.</typeparam>
        /// <param name="flagValue">Flag value.</param>
        /// <returns>Collection of flags.</returns>
        internal static List<string> FlagsToList<T>(uint flagValue) => (from T f in Enum.GetValues(typeof(T))
                                                                        let f_ui = Convert.ToUInt32(f)
                                                                        where (flagValue & f_ui) > 0 || flagValue == f_ui
                                                                        select f.ToString()).ToList();

        /// <summary>
        /// Get a string representation of flags.
        /// </summary>
        /// <typeparam name="T">Flag collection type.</typeparam>
        /// <param name="flagValue">Flag vlaue</param>
        /// <returns>String representation of flags in the f1 | ... | fn format.</returns>
        internal static string FlagsToString<T>(uint flagValue)
        {
            var flags = new List<string>();
            flags.AddRange(FlagsToList<T>(flagValue));
            return string.Join(" | ", flags?.ToArray());
        }
    }

    /// <summary>
    /// This structure depicts the organization of data in a file-version resource. 
    /// It contains version information that can be displayed for a particular language and code page.
    /// http://msdn.microsoft.com/en-us/library/aa908808.aspx
    /// </summary>
    public class StringFileInfo : ResourceTableHeader
    {
        /// <summary>
        /// Resource strings.
        /// </summary>
        public Dictionary<string, StringTable> Strings { get; } = new Dictionary<string, StringTable>();

        /// <summary>
        /// An existing string file-version resource.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of a string file-version resource.</param>
        internal StringFileInfo(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read an existing string file-version resource.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of a string file-version resource.</param>
        /// <returns>Pointer to the end of the string file-version resource.</returns>
        internal override IntPtr Read(IntPtr lpRes)
        {
            Strings.Clear();
            IntPtr pChild = base.Read(lpRes);

            while (pChild.ToInt64() < (lpRes.ToInt64() + _header.wLength))
            {
                var res = new StringTable(pChild);
                Strings.Add(res.Key, res);
                pChild = ResourceUtil.Align(pChild.ToInt64() + res.Header.wLength);
            }

            return new IntPtr(lpRes.ToInt64() + _header.wLength);
        }

        /// <summary>
        /// Write the string file-version resource to a binary stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        internal override void Write(BinaryWriter w)
        {
            long headerPos = w.BaseStream.Position;
            base.Write(w);

            Dictionary<string, StringTable>.Enumerator stringsEnum = Strings.GetEnumerator();
            while (stringsEnum.MoveNext())
            {
                stringsEnum.Current.Value.Write(w);
            }

            ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
            ResourceUtil.PadToDWORD(w);
        }

        /// <summary>
        /// Default (first) string table.
        /// </summary>
        public StringTable Default
        {
            get
            {
                Dictionary<string, StringTable>.Enumerator iter = Strings.GetEnumerator();
                return iter.MoveNext() ? iter.Current.Value : null;
            }
        }

        /// <summary>
        /// Indexed string table.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>A string table at a given index.</returns>
        public string this[string key]
        {
            get => Default[key];
            set => Default[key] = value;
        }

        /// <summary>
        /// String representation of StringFileInfo.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String in the StringFileInfo format.</returns>
        public override string ToString(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{new string(' ', indent)}BEGIN");
            sb.AppendLine($"{new string(' ', indent + 1)}BLOCK \"{_key}\"");
            foreach (StringTable stringTable in Strings.Values)
            {
                sb.Append(stringTable.ToString(indent + 1));
            }
            sb.AppendLine($"{new string(' ', indent)}END");
            return sb?.ToString();
        }
    }
    /// <summary>
    /// This structure depicts the organization of data in a file-version resource. It contains language 
    /// and code page formatting information for the strings. A code page is an ordered character set.
    /// See http://msdn.microsoft.com/en-us/library/aa909192.aspx for more information.
    /// </summary>
    public class StringTable : ResourceTableHeader
    {
        /// <summary>
        /// Resource strings.
        /// </summary>
        public Dictionary<string, StringTableEntry> Strings { get; } = new Dictionary<string, StringTableEntry>();

        /// <summary>
        /// An existing string table.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of the table.</param>
        internal StringTable(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read a string table.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of the string table.</param>
        /// <returns>Pointer to the end of the string table.</returns>
        internal override IntPtr Read(IntPtr lpRes)
        {
            Strings.Clear();
            IntPtr pChild = base.Read(lpRes);

            while (pChild.ToInt64() < (lpRes.ToInt64() + _header.wLength))
            {
                var res = new StringTableEntry(pChild);
                Strings.Add(res.Key, res);
                pChild = ResourceUtil.Align(pChild.ToInt64() + res.Header.wLength);
            }

            return new IntPtr(lpRes.ToInt64() + _header.wLength);
        }

        /// <summary>
        /// Write the string table to a binary stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <returns>Last unpadded position.</returns>
        internal override void Write(BinaryWriter w)
        {
            long headerPos = w.BaseStream.Position;
            base.Write(w);

            int total = Strings.Count;
            Dictionary<string, StringTableEntry>.Enumerator stringsEnum = Strings.GetEnumerator();
            while (stringsEnum.MoveNext())
            {
                stringsEnum.Current.Value.Write(w);
                ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
                // total parent structure size must not include padding
                if (--total != 0)
                {
                    ResourceUtil.PadToDWORD(w);
                }
            }
        }

        /// <summary>
        /// The four most significant digits of the key represent the language identifier.
        /// Each Microsoft Standard Language identifier contains two parts: the low-order 10 bits 
        /// specify the major language, and the high-order 6 bits specify the sublanguage.
        /// </summary>
        public ushort LanguageID
        {
            get => string.IsNullOrEmpty(_key) ? (ushort)0 : Convert.ToUInt16(_key.Substring(0, 4), 16);
            set => _key = $"{value:x4}{CodePage:x4}";
        }

        /// <summary>
        /// The four least significant digits of the key represent the code page for which the data is formatted.
        /// </summary>
        public ushort CodePage
        {
            get => string.IsNullOrEmpty(_key) ? (ushort)0 : Convert.ToUInt16(_key.Substring(4, 4), 16);
            set => _key = $"{LanguageID:x4}{value:x4}";
        }

        /// <summary>
        /// Returns an entry within the string table.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>An entry within the string table.</returns>
        public string this[string key]
        {
            get => Strings[key].Value;
            set
            {
                if (!Strings.TryGetValue(key, out StringTableEntry sr))
                {
                    sr = new StringTableEntry(key);
                    Strings.Add(key, sr);
                }

                sr.Value = value;
            }
        }

        /// <summary>
        /// String representation of the string table.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String representation of the strings table.</returns>
        public override string ToString(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{new string(' ', indent)}BEGIN");
            sb.AppendLine($"{new string(' ', indent + 1)}BLOCK \"{_key}\"");
            sb.AppendLine($"{new string(' ', indent + 1)}BEGIN");
            foreach (StringTableEntry stringResource in Strings.Values)
            {
                sb.AppendLine($"{new string(' ', indent + 2)}VALUE \"{stringResource.Key}\", \"{stringResource.StringValue}\"");
            }
            sb.AppendLine($"{new string(' ', indent + 1)}END");
            sb.AppendLine($"{new string(' ', indent)}END");
            return sb?.ToString();
        }
    }
    /// <summary>
    /// This structure depicts the organization of data in a file-version resource. It contains a string 
    /// that describes a specific aspect of a file, such as a file's version, its copyright notices, 
    /// or its trademarks.
    /// http://msdn.microsoft.com/en-us/library/aa909025.aspx
    /// </summary>
    public class StringTableEntry
    {
        private Structures.RESOURCE_HEADER _header;
        /// <summary>
        /// The value is always stored double-null-terminated.
        /// </summary>
        private string _value;

        /// <summary>
        /// String resource header.
        /// </summary>
        public Structures.RESOURCE_HEADER Header => _header;

        /// <summary>
        /// Key.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// String value (removing the double-null-terminator).
        /// </summary>
        public string StringValue => _value != null ? _value.Substring(0, _value.Length - 1) : _value;

        /// <summary>
        /// Value.
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                if (value != null)
                {
                    _value = value.Length == 0 || value[value.Length - 1] != '\0' ? value + '\0' : value;
                    _header.wValueLength = (ushort)_value.Length;
                }
                else
                {
                    _value = null;
                    _header.wValueLength = 0;
                }
            }
        }

        /// <summary>
        /// A new string resource.
        /// </summary>
        /// <param name="key">Key.</param>
        public StringTableEntry(string key)
        {
            Key = key;
            _header.wType = 1;
            _header.wLength = 0;
            _header.wValueLength = 0;
        }

        /// <summary>
        /// An existing string resource.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of a string resource.</param>
        internal StringTableEntry(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read a string resource.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of a string resource.</param>
        internal void Read(IntPtr lpRes)
        {
            _header = (Structures.RESOURCE_HEADER)Marshal.PtrToStructure(lpRes, typeof(Structures.RESOURCE_HEADER));

            IntPtr pKey = new IntPtr(lpRes.ToInt64() + Marshal.SizeOf(_header));
            Key = Marshal.PtrToStringUni(pKey);

            IntPtr pValue = ResourceUtil.Align(pKey.ToInt64() + ((Key.Length + 1) * Marshal.SystemDefaultCharSize));
            _value = (_header.wValueLength > 0) ? Marshal.PtrToStringUni(pValue, _header.wValueLength) : null;
        }

        /// <summary>
        /// Write a string resource to a binary stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        internal void Write(BinaryWriter w)
        {
            // write the block info
            long headerPos = w.BaseStream.Position;
            // wLength
            w.Write(_header.wLength);
            // wValueLength
            w.Write(_header.wValueLength);
            // wType
            w.Write(_header.wType);
            // szKey
            w.Write(Encoding.Unicode.GetBytes(Key));
            // null terminator
            w.Write((ushort)0);
            // pad fixed info
            ResourceUtil.PadToDWORD(w);
            long valuePos = w.BaseStream.Position;
            if (_value != null)
            {
                // value (always double-null-terminated)
                w.Write(Encoding.Unicode.GetBytes(_value));
            }
            // wValueLength
            ResourceUtil.WriteAt(w, (w.BaseStream.Position - valuePos) / Marshal.SystemDefaultCharSize, headerPos + 2);
            // wLength
            ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
        }
    }
    /// <summary>
    /// This structure depicts the organization of data in a file-version resource. 
    /// It contains version information not dependent on a particular language and code page combination.
    /// http://msdn.microsoft.com/en-us/library/aa909193.aspx
    /// </summary>
    public class VarFileInfo : ResourceTableHeader
    {
        /// <summary>
        /// A hardware independent dictionary of language and code page identifier tables.
        /// </summary>
        public Dictionary<string, VarTable> Vars { get; } = new Dictionary<string, VarTable>();

        /// <summary>
        /// An existing hardware independent dictionary of language and code page identifier tables.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of data.</param>
        internal VarFileInfo(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read a hardware independent dictionary of language and code page identifier tables.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of data.</param>
        /// <returns>Pointer to the end of data.</returns>
        internal override IntPtr Read(IntPtr lpRes)
        {
            Vars.Clear();
            IntPtr pChild = base.Read(lpRes);

            while (pChild.ToInt64() < (lpRes.ToInt64() + _header.wLength))
            {
                var res = new VarTable(pChild);
                Vars.Add(res.Key, res);
                pChild = ResourceUtil.Align(pChild.ToInt64() + res.Header.wLength);
            }

            return new IntPtr(lpRes.ToInt64() + _header.wLength);
        }

        /// <summary>
        /// Write the hardware independent dictionary of language and code page identifier tables to a binary stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        internal override void Write(BinaryWriter w)
        {
            long headerPos = w.BaseStream.Position;
            base.Write(w);

            Dictionary<string, VarTable>.Enumerator varsEnum = Vars.GetEnumerator();
            while (varsEnum.MoveNext())
            {
                varsEnum.Current.Value.Write(w);
            }

            ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
        }

        /// <summary>
        /// The default language and code page identifier table.
        /// </summary>
        public VarTable Default
        {
            get
            {
                Dictionary<string, VarTable>.Enumerator varsEnum = Vars.GetEnumerator();
                return varsEnum.MoveNext() ? varsEnum.Current.Value : null;
            }
        }

        /// <summary>
        /// Returns a language and code page identifier table.
        /// </summary>
        /// <param name="language">Language ID.</param>
        /// <returns>A language and code page identifier table.</returns>
        public ushort this[ushort language]
        {
            get => Default[language];
            set => Default[language] = value;
        }

        /// <summary>
        /// String representation of VarFileInfo.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String in the VarFileInfo format.</returns>
        public override string ToString(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{new string(' ', indent)}BEGIN");
            foreach (VarTable var in Vars.Values)
            {
                sb.Append(var?.ToString(indent + 1));
            }
            sb.AppendLine($"{new string(' ', indent)}END");
            return sb?.ToString();
        }
    }
    /// <summary>
    /// This structure depicts the organization of data in a file-version resource. It typically contains a 
    /// list of language and code page identifier pairs that the version of the application or DLL supports.
    /// http://msdn.microsoft.com/en-us/library/bb202818.aspx
    /// </summary>
    public class VarTable : ResourceTableHeader
    {
        /// <summary>
        /// A dictionary of language and code page identifier pairs.
        /// </summary>
        public Dictionary<ushort, ushort> Languages { get; } = new Dictionary<ushort, ushort>();

        /// <summary>
        /// A new table of language and code page identifier pairs.
        /// </summary>
        /// <param name="key">Table key.</param>
        public VarTable(string key) : base(key) { }

        /// <summary>
        /// An existing table of language and code page identifier pairs.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of the data.</param>
        internal VarTable(IntPtr lpRes)
        {
            Read(lpRes);
        }

        /// <summary>
        /// Read a table of language and code page identifier pairs.
        /// </summary>
        /// <param name="lpRes">Pointer to the beginning of the data.</param>
        /// <returns></returns>
        internal override IntPtr Read(IntPtr lpRes)
        {
            Languages.Clear();
            IntPtr pVar = base.Read(lpRes);

            while (pVar.ToInt64() < (lpRes.ToInt64() + _header.wLength))
            {
                var var = (Structures.VAR_HEADER)Marshal.PtrToStructure(pVar, typeof(Structures.VAR_HEADER));
                Languages.Add(var.wLanguageIDMS, var.wCodePageIBM);
                pVar = new IntPtr(pVar.ToInt64() + Marshal.SizeOf(var));
            }

            return new IntPtr(lpRes.ToInt64() + _header.wLength);
        }

        /// <summary>
        /// Write the table of language and code page identifier pairs to a binary stream.
        /// </summary>
        /// <param name="w">Binary stream.</param>
        /// <returns>Last unpadded position.</returns>
        internal override void Write(BinaryWriter w)
        {
            long headerPos = w.BaseStream.Position;
            base.Write(w);

            Dictionary<ushort, ushort>.Enumerator languagesEnum = Languages.GetEnumerator();
            long valuePos = w.BaseStream.Position;
            while (languagesEnum.MoveNext())
            {
                // id
                w.Write(languagesEnum.Current.Key);
                // code page
                w.Write(languagesEnum.Current.Value);
            }

            ResourceUtil.WriteAt(w, w.BaseStream.Position - valuePos, headerPos + 2);
            ResourceUtil.PadToDWORD(w);
            ResourceUtil.WriteAt(w, w.BaseStream.Position - headerPos, headerPos);
        }

        /// <summary>
        /// Returns a code page identifier for a given language.
        /// </summary>
        /// <param name="key">Language ID.</param>
        /// <returns>Code page identifier.</returns>
        public ushort this[ushort key]
        {
            get => Languages[key];
            set => Languages[key] = value;
        }

        /// <summary>
        /// String representation of the var table.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String representation of the var table.</returns>
        public override string ToString(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{new string(' ', indent)}BEGIN");
            Dictionary<ushort, ushort>.Enumerator languagesEnumerator = Languages.GetEnumerator();
            while (languagesEnumerator.MoveNext())
            {
                sb.AppendLine($"{new string(' ', indent + 1)}VALUE \"Translation\", 0x{languagesEnumerator.Current.Key:x}, 0x{languagesEnumerator.Current.Value:x}");
            }
            sb.AppendLine($"{new string(' ', indent)}END");
            return sb?.ToString();
        }
    }
}