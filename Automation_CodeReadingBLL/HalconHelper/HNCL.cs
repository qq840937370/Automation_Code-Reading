//
// File generated by HDevelop for HALCON/.NET (C#) Version 18.11.1.1
// Non-ASCII strings in this file are encoded in UTF-8.
// 
// Please note that non-ASCII characters in string constants are exported
// as octal codes in order to guarantee that the strings are correctly
// created on all systems, independent on any compiler settings.
// 
// Source files with different encoding should not be mixed in one project.
//
using HalconDotNet;
// 高净值耗材使用清单
public class HNCL
{
    private int imgNumber = 0;
    private HTuple hv_ExpDefaultWinHandle;
    private HTuple hv_ExpImageRawWinHandle;
    private HTuple hv_Mean = null, hv_Deviation = null;
    HTuple acqHandle = new HTuple();
    HDevelop hDevelo = new HDevelop();

    /// <summary>
    /// 高净值耗材使用清单入口方法
    /// </summary>
    /// <param name="AcqHandle"></param>
    /// <param name="Window"></param>
    /// <param name="ImageRawWin"></param>
    public void RunHalcon_HNCL(HTuple AcqHandle, HTuple Window, HTuple ImageRawWin)
    {
        acqHandle = AcqHandle;
        hv_ExpDefaultWinHandle = Window;
        hv_ExpImageRawWinHandle = ImageRawWin;
        action();
    }
    // Main procedure 
    private void action()
    {
        // Stack for temporary objects 
        HObject[] OTemp = new HObject[20];

        // Local iconic variables 

        HObject ho_Image = null, ho_SymbolXLDs = null;
        HObject ho_SymbolRegions = null, ho_ObjectSelected = null;

        // Local control variables 

        HTuple hv_BarWidth = new HTuple(), hv_BarHeight = new HTuple();
        HTuple hv_DataCodeHandle = new HTuple(), hv_BarCodeHandle = new HTuple();
        HTuple hv_WindowHandle = new HTuple(), hv_AcqHandle = new HTuple();
        HTuple hv_ResultHandles = new HTuple(), hv_DecodedDataStrings = new HTuple();
        HTuple hv_someitem = new HTuple(), hv_Area = new HTuple();
        HTuple hv_BarIndex = new HTuple(), hv_Row = new HTuple();
        HTuple hv_Column = new HTuple(), hv_Exception = new HTuple();
        // Initialize local and output iconic variables 
        HOperatorSet.GenEmptyObj(out ho_Image);
        HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
        HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
        HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
        try
        {
            //***
            //** INIT
            //* INIT CONST
            hv_BarWidth.Dispose();
            hv_BarWidth = 800;
            hv_BarHeight.Dispose();
            hv_BarHeight = 100;
            //* INIT IMAGE
            //* INIT DATACODE
            hv_DataCodeHandle.Dispose();
            HOperatorSet.CreateDataCode2dModel("Data Matrix ECC 200", new HTuple(), new HTuple(),
                out hv_DataCodeHandle);

            //* INIT BARCODE
            hv_BarCodeHandle.Dispose();
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
            HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "quiet_zone", "true");
            //* INIT LOC
            //* Info:
            //read_shape_model ('C:/Users/iwake/OneDrive - wake/Desktop/Localization/InvV1CaliInfo.shm', InfoModel)
            //get_shape_model_contours (InfoModelContours, InfoModel, 1)
            //* Sign
            //read_shape_model ('C:/Users/iwake/OneDrive - wake/Desktop/Localization/InvV1CaliSign.shm', SignModel)
            //get_shape_model_contours (SignModelContours, SignModel, 1)
            //***
            //** DISPLAY
            //* DISPLAY INIT
            hDevelo.dev_update_off();
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.CloseWindow(HDevWindowStack.Pop());
            }
            HOperatorSet.SetWindowAttr("background_color", "black");
            //HOperatorSet.OpenWindow(30, 0, 800, 1500, 0, "visible", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_ExpDefaultWinHandle);


            //***
            //** LOOP
            //Image Acquisition 01: Code generated by Image Acquisition 01
            hv_AcqHandle.Dispose();
            hv_AcqHandle = acqHandle;
            while ((int)(1) != 0)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
                {
                    HObject ExpTmpOutVar_0;
                    hDevelo.image_cali_map(ho_Image, out ExpTmpOutVar_0, new HTuple(), new HTuple());
                    ho_Image.Dispose();
                    ho_Image = ExpTmpOutVar_0;
                    HOperatorSet.DispObj(ho_Image, hv_ExpImageRawWinHandle);
                }
                try
                {
                    //** PRE
                    //find_shape_model (Image, SignModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.6, InfoRow, InfoColumn, InfoAngle, InfoScore)
                    //rotate_image (Image, Image, deg(-InfoAngle), 'constant')
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                    }
                    //** RECOGNITION
                    //* DataCode
                    ho_SymbolXLDs.Dispose(); hv_ResultHandles.Dispose(); hv_DecodedDataStrings.Dispose();
                    HOperatorSet.FindDataCode2d(ho_Image, out ho_SymbolXLDs, hv_DataCodeHandle,
                        "stop_after_result_num", 3, out hv_ResultHandles, out hv_DecodedDataStrings);
                    hDevelo.image_display_datacode(ho_SymbolXLDs, hv_ResultHandles, hv_WindowHandle,
              hv_DecodedDataStrings, hv_DataCodeHandle);
                    //* BARCODE
                    ho_SymbolRegions.Dispose(); hv_DecodedDataStrings.Dispose(); hv_someitem.Dispose();
                    hDevelo.image_get_bar(ho_Image, out ho_SymbolRegions, hv_BarCodeHandle, out hv_DecodedDataStrings,
              out hv_someitem);
                    //* LOC
                    //* Info:
                    //find_shape_model (Image, InfoModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.7, InfoRow, InfoColumn, InfoAngle, InfoScore)
                    //* HaedSign
                    //find_shape_model (Image, SignModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.7, SignRow, SignColumn, SignAngle, SignScore)
                    //* Ocr
                    //gen_rectangle2 (ROI_OCR_01_0, InfoRow + 70, InfoColumn - 700, InfoAngle, 100, 30)
                    //region_ocr_num_svm (Image, ROI_OCR_01_0, [], [], SymbolNames_OCR_01_0, Ocr_Split)
                    //area_center (ROI_OCR_01_0, Area, IDRow, IDColumn)
                    //smallest_rectangle1 (ROI_OCR_01_0, IDRow1, IDColumn1, IDRow2, IDColumn2)
                    //height_width_ratio (ROI_OCR_01_0, IDHeight, IDWidth, IDRatio)
                    //* Sign
                    //HeadSignScale := 1
                    //HeadSignRow := SignRow
                    //HeadSignCol := SignColumn
                    //HeadPhi := SignAngle
                    //region_judge_sign (Image, EDGE, HeadSignScale, HeadSignRow, HeadSignCol, HeadPhi, WindowHandle, sign)
                    //** DISPLAY
                    //* DISPLAY BARCODE
                    hDevelo.set_display_font(hv_WindowHandle, 14, "mono", "true", "false");
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 3);
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.SetColor(HDevWindowStack.GetActive(), "forest green");
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.DispObj(ho_SymbolRegions, HDevWindowStack.GetActive());
                    }
                    for (hv_BarIndex = 1; (int)hv_BarIndex <= (int)(new HTuple(hv_DecodedDataStrings.TupleLength()
                        )); hv_BarIndex = (int)hv_BarIndex + 1)
                    {
                        ho_ObjectSelected.Dispose();
                        HOperatorSet.SelectObj(ho_SymbolRegions, out ho_ObjectSelected, hv_BarIndex);
                        hv_Area.Dispose(); hv_Row.Dispose(); hv_Column.Dispose();
                        HOperatorSet.AreaCenter(ho_ObjectSelected, out hv_Area, out hv_Row, out hv_Column);
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            HOperatorSet.SetTposition(hv_WindowHandle, hv_Row - hv_BarHeight, hv_Column - (0.25 * hv_BarWidth));
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            HOperatorSet.WriteString(hv_WindowHandle, hv_DecodedDataStrings.TupleSelect(
                                hv_BarIndex - 1));
                        }
                    }
                    //* DISPLAY LOC
                    if (HDevWindowStack.IsOpen())
                    {
                        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
                    }
                    //* Info:
                    //hom_mat2d_identity (InfoHomMat2D)
                    //hom_mat2d_rotate (InfoHomMat2D, InfoAngle, 0, 0, InfoHomMat2D)
                    //hom_mat2d_translate (InfoHomMat2D, InfoRow, InfoColumn, InfoHomMat2D)
                    //affine_trans_contour_xld (InfoModelContours, InfoTransContours, InfoHomMat2D)
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_set_color ('green')
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_display (InfoTransContours)
                    }
                    //* Ocr
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_disp_text (Ocr_Split, 'image', IDRow1 + IDHeight, IDColumn1, 'blue', [], [])
                    }
                    //* HeadSign
                    //hom_mat2d_identity (SignHomMat2D)
                    //hom_mat2d_rotate (SignHomMat2D, SignAngle, 0, 0, SignHomMat2D)
                    //hom_mat2d_translate (SignHomMat2D, SignRow, SignColumn, SignHomMat2D)
                    //affine_trans_contour_xld (SignModelContours, SignTransContours, SignHomMat2D)
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_set_color ('green')
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_display (SignTransContours)
                    }
                    //* Sign
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_set_colored (12)
                    }
                    if (HDevWindowStack.IsOpen())
                    {
                        //dev_display (EDGE)
                    }
                    //dump_window_image (ImageResult, WindowHandle)

                    //stop ()
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                }

            }
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);




        }
        catch (HalconException HDevExpDefaultException)
        {
            ho_Image.Dispose();
            ho_SymbolXLDs.Dispose();
            ho_SymbolRegions.Dispose();
            ho_ObjectSelected.Dispose();

            hv_BarWidth.Dispose();
            hv_BarHeight.Dispose();
            hv_DataCodeHandle.Dispose();
            hv_BarCodeHandle.Dispose();
            hv_WindowHandle.Dispose();
            hv_AcqHandle.Dispose();
            hv_ResultHandles.Dispose();
            hv_DecodedDataStrings.Dispose();
            hv_someitem.Dispose();
            hv_Area.Dispose();
            hv_BarIndex.Dispose();
            hv_Row.Dispose();
            hv_Column.Dispose();
            hv_Exception.Dispose();

            throw HDevExpDefaultException;
        }
        ho_Image.Dispose();
        ho_SymbolXLDs.Dispose();
        ho_SymbolRegions.Dispose();
        ho_ObjectSelected.Dispose();

        hv_BarWidth.Dispose();
        hv_BarHeight.Dispose();
        hv_DataCodeHandle.Dispose();
        hv_BarCodeHandle.Dispose();
        hv_WindowHandle.Dispose();
        hv_AcqHandle.Dispose();
        hv_ResultHandles.Dispose();
        hv_DecodedDataStrings.Dispose();
        hv_someitem.Dispose();
        hv_Area.Dispose();
        hv_BarIndex.Dispose();
        hv_Row.Dispose();
        hv_Column.Dispose();
        hv_Exception.Dispose();

    }
}

