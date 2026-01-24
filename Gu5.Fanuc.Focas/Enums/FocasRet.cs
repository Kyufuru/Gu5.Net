namespace Gu5.Fanuc.Focas.Enums
{
    /* Error Codes */
    internal enum FocasRet
    {
        EW_PROTOCOL = (-17),           /* protocol error */
        EW_SOCKET = (-16),           /* Windows socket error */
        EW_NODLL = (-15),           /* DLL not exist error */
        EW_BUS = (-11),           /* bus error */
        EW_SYSTEM2 = (-10),           /* system error */
        EW_HSSB = (-9),           /* hssb communication error */
        EW_HANDLE = (-8),           /* Windows library handle error */
        EW_VERSION = (-7),           /* CNC/PMC version missmatch */
        EW_UNEXP = (-6),           /* abnormal error */
        EW_SYSTEM = (-5),           /* system error */
        EW_PARITY = (-4),           /* shared RAM parity error */
        EW_MMCSYS = (-3),           /* emm386 or mmcsys install error */
        EW_RESET = (-2),           /* reset or stop occured error */
        EW_BUSY = (-1),           /* busy error */
        EW_OK = 0,           /* no problem */
        EW_FUNC = 1,           /* command prepare error */
        EW_NOPMC = 1,           /* pmc not exist */
        EW_LENGTH = 2,           /* data block length error */
        EW_NUMBER = 3,           /* data number error */
        EW_RANGE = 3,           /* address range error */
        EW_ATTRIB = 4,           /* data attribute error */
        EW_TYPE = 4,           /* data type error */
        EW_DATA = 5,           /* data error */
        EW_NOOPT = 6,           /* no option error */
        EW_PROT = 7,           /* write protect error */
        EW_OVRFLOW = 8,           /* memory overflow error */
        EW_PARAM = 9,           /* cnc parameter not correct error */
        EW_BUFFER = 10,           /* buffer error */
        EW_PATH = 11,           /* path error */
        EW_MODE = 12,           /* cnc mode error */
        EW_REJECT = 13,           /* execution rejected error */
        EW_DTSRVR = 14,           /* data server error */
        EW_ALARM = 15,           /* alarm has been occurred */
        EW_STOP = 16,           /* CNC is not running */
        EW_PASSWD = 17,           /* protection data error */
        /*
            Result codes of DNC operation
        */
        DNC_NORMAL = (-1),           /* normal completed */
        DNC_CANCEL = (-32768),           /* DNC operation was canceled by CNC */
        DNC_OPENERR = (-514),           /* file open error */
        DNC_NOFILE = (-516),           /* file not found */
        DNC_READERR = (-517)              /* read error */
    };
}
