﻿#if !NoCCL
using CommunityCoreLibrary;
using CommunityCoreLibrary.UI;
# endif
using System;
using System.Collections.Generic;
using System.IO;
using ColonistBarKF.PSI;
using RW_ColonistBarKF;
using UnityEngine;
using Verse;
using static ColonistBarKF.CBKF;
using static ColonistBarKF.PSI.PSI;
using static ColonistBarKF.SettingsColonistBar.SortByWhat;
using static UnityEngine.GUILayout;

namespace ColonistBarKF
{
#if !NoCCL
    public class ModConfigMenu : ModConfigurationMenu
#else
    public class ColonistBarKF_Settings : Window
#endif
    {
        #region Fields

        public Window OptionsDialog;

        #endregion

        #region Methods

        public static int lastupdate = -5000;

        public override void WindowUpdate()
        {
            Reinit(false, true);
            //  if (Find.TickManager.TicksGame > lastupdate)
            //  {
            //
            //    //if (ColBarSettings.UseGender)
            //    //    ColonistBarTextures.BGTex = ColonistBarTextures.BGTexGrey;
            //    //else
            //    //{
            //    //    ColonistBarTextures.BGTex = ColonistBarTextures.BGTexVanilla;
            //    //}
            //      lastupdate = Find.TickManager.TicksGame + 1500;
            //  }
        }


#if NoCCL
        public override void PreClose()
        {
            SaveBarSettings();
            SavePsiSettings();
        }



        public override Vector2 InitialSize => new Vector2(460f, 690f);

        private int mainToolbarInt = 0;
        private int psiToolbarInt = 0;
        private int barPositionInt = 0;
        private int psiBarPositionInt = 0;
        private int psiPositionInt = 0;

        public string[] mainToolbarStrings =
            {
            "CBKF.Settings.ColonistBar".Translate(),
            "CBKF.Settings.PSI".Translate()
        };
        public string[] psiToolbarStrings =
        {
            "PSI.Settings.ArrangementButton".Translate(),
            "PSI.Settings.OpacityButton".Translate(),
            "PSI.Settings.IconButton".Translate(),
            "PSI.Settings.SensitivityButton".Translate(),
        };

        public string[] psiPositionStrings =
        {
            "CBKF.Settings.useTop".Translate(),
            "CBKF.Settings.useBottom".Translate(),
            "CBKF.Settings.useLeft".Translate(),
            "CBKF.Settings.useRight".Translate()
        };

        private string[] psiColBarStrings =
{
            "CBKF.Settings.useLeft".Translate(),
            "CBKF.Settings.useRight".Translate(),
            "CBKF.Settings.useTop".Translate(),
            "CBKF.Settings.useBottom".Translate()
        };

        private int MainToolbarInt
        {
            get
            {
                return mainToolbarInt;
            }

            set
            {
                mainToolbarInt = value;
            }
        }

        private int BarPositionInt
        {
            get
            {
                if (!ColBarSettings.UseBottomAlignment && !ColBarSettings.UseVerticalAlignment && !ColBarSettings.UseRightAlignment)
                {
                    barPositionInt = 0;
                }
                if (ColBarSettings.UseBottomAlignment && !ColBarSettings.UseVerticalAlignment && !ColBarSettings.UseRightAlignment)
                {
                    barPositionInt = 1;
                }
                if (!ColBarSettings.UseBottomAlignment && ColBarSettings.UseVerticalAlignment && !ColBarSettings.UseRightAlignment)
                {
                    barPositionInt = 2;
                }
                if (!ColBarSettings.UseBottomAlignment && ColBarSettings.UseVerticalAlignment && ColBarSettings.UseRightAlignment)
                {
                    barPositionInt = 3;
                }
                return barPositionInt;
            }

            set
            {
                switch (value)
                {
                    case 0:
                        ColBarSettings.UseBottomAlignment = false;
                        ColBarSettings.UseVerticalAlignment = false;
                        ColBarSettings.UseRightAlignment = false;
                        break;
                    case 1:
                        ColBarSettings.UseBottomAlignment = true;
                        ColBarSettings.UseVerticalAlignment = false;
                        ColBarSettings.UseRightAlignment = false; break;
                    case 2:
                        ColBarSettings.UseBottomAlignment = false;
                        ColBarSettings.UseVerticalAlignment = true;
                        ColBarSettings.UseRightAlignment = false; break;
                    case 3:
                        ColBarSettings.UseBottomAlignment = false;
                        ColBarSettings.UseVerticalAlignment = true;
                        ColBarSettings.UseRightAlignment = true; break;
                    default:
                        ColBarSettings.UseBottomAlignment = false;
                        ColBarSettings.UseVerticalAlignment = false;
                        ColBarSettings.UseRightAlignment = false;
                        break;
                }

                barPositionInt = value;
            }
        }

        private int PsiBarPositionInt
        {
            get
            {

                if (ColBarSettings.IconAlignment == 0)
                {
                    psiBarPositionInt = 0;
                }
                if (ColBarSettings.IconAlignment == 1)
                {
                    psiBarPositionInt = 1;
                }
                if (ColBarSettings.IconAlignment == 2)
                {
                    psiBarPositionInt = 2;
                }
                if (ColBarSettings.IconAlignment == 3)
                {
                    psiBarPositionInt = 3;
                }
                return psiBarPositionInt;
            }

            set
            {
                if (value == psiBarPositionInt)
                    return;
                switch (value)
                {
                    case 0:
                        ColBarSettings.IconAlignment = value;
                        ColBarSettings.IconDistanceX = 1f;
                        ColBarSettings.IconDistanceY = 1f;
                        ColBarSettings.IconOffsetX = 1f;
                        ColBarSettings.IconOffsetY = 1f;
                        ColBarSettings.IconsHorizontal = false;
                        ColBarSettings.IconsScreenScale = true;
                        ColBarSettings.IconsInColumn = 4;
                        ColBarSettings.IconSize = 1f;
                        ColBarSettings.IconOpacity = 0.7f;
                        ColBarSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 1:
                        ColBarSettings.IconAlignment = value;
                        ColBarSettings.IconDistanceX = -1f;
                        ColBarSettings.IconDistanceY = 1f;
                        ColBarSettings.IconOffsetX = -1f;
                        ColBarSettings.IconOffsetY = 1f;
                        ColBarSettings.IconsHorizontal = false;
                        ColBarSettings.IconsScreenScale = true;
                        ColBarSettings.IconsInColumn = 4;
                        ColBarSettings.IconSize = 1f;
                        ColBarSettings.IconOpacity = 0.7f;
                        ColBarSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 2:
                        ColBarSettings.IconAlignment = value;
                        ColBarSettings.IconDistanceX = 1f;
                        ColBarSettings.IconDistanceY = -1;
                        ColBarSettings.IconOffsetX = -1f;
                        ColBarSettings.IconOffsetY = 1f;
                        ColBarSettings.IconsHorizontal = true;
                        ColBarSettings.IconsScreenScale = true;
                        ColBarSettings.IconsInColumn = 4;
                        ColBarSettings.IconSize = 1f;
                        ColBarSettings.IconOpacity = 0.7f;
                        ColBarSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 3:
                        ColBarSettings.IconAlignment = value;
                        ColBarSettings.IconDistanceX = 1;
                        ColBarSettings.IconDistanceY = 1;
                        ColBarSettings.IconOffsetX = -1;
                        ColBarSettings.IconOffsetY = -1;
                        ColBarSettings.IconsHorizontal = true;
                        ColBarSettings.IconsScreenScale = true;
                        ColBarSettings.IconsInColumn = 4;
                        ColBarSettings.IconSize = 1f;
                        ColBarSettings.IconOpacity = 0.7f;
                        ColBarSettings.IconOpacityCritical = 0.6f;
                        break;
                    default:
                        ColBarSettings.IconAlignment = 0;

                        break;
                }
                psiBarPositionInt = value;
            }
        }

        private int PsiPositionInt
        {
            get
            {

                if (PsiSettings.IconAlignment == 0)
                {
                    psiPositionInt = 0;
                }
                if (PsiSettings.IconAlignment == 1)
                {
                    psiPositionInt = 1;
                }
                if (PsiSettings.IconAlignment == 2)
                {
                    psiPositionInt = 2;
                }
                if (PsiSettings.IconAlignment == 3)
                {
                    psiPositionInt = 3;
                }
                return psiPositionInt;
            }

            set
            {
                if (value == psiPositionInt)
                    return;
                switch (value)
                {
                    case 0:
                        PsiSettings.IconAlignment = value;
                        PsiSettings.IconDistanceX = 1f;
                        PsiSettings.IconDistanceY = 1f;
                        PsiSettings.IconOffsetX = 1f;
                        PsiSettings.IconOffsetY = 1f;
                        PsiSettings.IconsHorizontal = false;
                        PsiSettings.IconsScreenScale = true;
                        PsiSettings.IconsInColumn = 3;
                        PsiSettings.IconSize = 1f;
                        PsiSettings.IconOpacity = 0.7f;
                        PsiSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 1:
                        PsiSettings.IconAlignment = value;
                        PsiSettings.IconDistanceX = -1f;
                        PsiSettings.IconDistanceY = 1f;
                        PsiSettings.IconOffsetX = -1f;
                        PsiSettings.IconOffsetY = 1f;
                        PsiSettings.IconsHorizontal = false;
                        PsiSettings.IconsScreenScale = true;
                        PsiSettings.IconsInColumn = 3;
                        PsiSettings.IconSize = 1f;
                        PsiSettings.IconOpacity = 0.7f;
                        PsiSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 2:
                        PsiSettings.IconAlignment = value;
                        PsiSettings.IconDistanceX = 1f;
                        PsiSettings.IconDistanceY = -1.63f;
                        PsiSettings.IconOffsetX = -1f;
                        PsiSettings.IconOffsetY = 1f;
                        PsiSettings.IconsHorizontal = true;
                        PsiSettings.IconsScreenScale = true;
                        PsiSettings.IconsInColumn = 3;
                        PsiSettings.IconSize = 1f;
                        PsiSettings.IconOpacity = 0.7f;
                        PsiSettings.IconOpacityCritical = 0.6f;
                        break;
                    case 3:
                        PsiSettings.IconAlignment = value;
                        PsiSettings.IconDistanceX = 1.139534f;
                        PsiSettings.IconDistanceY = 1.375f;
                        PsiSettings.IconOffsetX = -0.9534883f;
                        PsiSettings.IconOffsetY = -0.9534884f;
                        PsiSettings.IconsHorizontal = true;
                        PsiSettings.IconsScreenScale = true;
                        PsiSettings.IconsInColumn = 4;
                        PsiSettings.IconSize = 1.084302f;
                        PsiSettings.IconOpacity = 0.7f;
                        PsiSettings.IconOpacityCritical = 0.6f;
                        break;
                    default:
                        PsiSettings.IconAlignment = 0;

                        break;
                }
                psiPositionInt = value;
            }
        }


        private int PSIToolbarInt
        {
            get
            {
                LoadBarSettings();
                LoadPsiSettings();
                return psiToolbarInt;
            }

            set
            {
                SaveBarSettings();
                SavePsiSettings();
                psiToolbarInt = value;
            }
        }

        GUIStyle FontBold = new GUIStyle
        {
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white },
            padding = new RectOffset(0, 0, 5, 0),
        };

        GUIStyle Headline = new GUIStyle
        {
            fontStyle = FontStyle.Bold,
            fontSize = 16,
            normal = { textColor = Color.white },
            padding = new RectOffset(0, 0, 12, 6),
        };

        GUIStyle hoverBox = new GUIStyle
        {
            hover = { background = ColonistBarTextures.GrayHover },
            normal = { background = ColonistBarTextures.GrayFond }
        };

        GUIStyle DarkGrayBG = new GUIStyle
        {
            normal = { background = ColonistBarTextures.GrayFond },
        };

        GUIStyle GrayLines = new GUIStyle
        {
            normal = { background = ColonistBarTextures.GrayLines },
        };

        public ColonistBarKF_Settings()
        {
            forcePause = true;
            doCloseX = true;
            draggable = true;
            drawShadow = true;
            preventCameraMotion = false;
            resizeable = true;

        }

        private Vector2 _scrollPosition;


        public override void DoWindowContents(Rect rect)
#else
        public override float DoWindowContents(Rect rect)
#endif
        {
            var viewRect = new Rect(rect);
            viewRect.height -= 10f;

            BeginArea(viewRect);
            BeginVertical();

            BeginHorizontal();
            FlexibleSpace();
            Label("Colonist Bar KF 0.15.3", Headline);
            FlexibleSpace();
            EndHorizontal();

            Space(Text.LineHeight / 2);

            BeginHorizontal();
            FlexibleSpace();
            MainToolbarInt = Toolbar(MainToolbarInt, mainToolbarStrings);
            FlexibleSpace();
            EndHorizontal();


            switch (MainToolbarInt)
            {
                case 0:
                    {

                        LabelHeadline("CBKF.Settings.BarPosition".Translate());

                        BeginVertical();

                        BeginHorizontal();
                        BarPositionInt = Toolbar(BarPositionInt, psiPositionStrings);
                        FlexibleSpace();
                        EndHorizontal();

                        Space(Text.LineHeight / 2);
                        FillPagePosition();

                        EndVertical();

                        LabelHeadline("CBKF.Settings.Advanced".Translate());

                        BeginVertical();
                        _scrollPosition = BeginScrollView(_scrollPosition);
                        FillPageOptions();
                        Space(Text.LineHeight / 2);
                        EndScrollView();
                        EndVertical();
                    }
                    break;
                case 1:
                    {

                        //                 LabelHeadline("PSI.Settings".Translate());
                        Space(Text.LineHeight);

                        BeginHorizontal();
                        FlexibleSpace();
                        PSIToolbarInt = SelectionGrid(PSIToolbarInt, psiToolbarStrings, 2);
                        FlexibleSpace();
                        EndHorizontal();

                        Space(Text.LineHeight);

                        if (PSIToolbarInt == 0)
                        {
                            {
                                FillPSIPageSizeArrangement();
                            }
                        }
                        else if (PSIToolbarInt == 1)
                        {
                            {
                                FillPagePSIOpacityAndColor();
                            }
                        }
                        else if (PSIToolbarInt == 2)
                        {
                            {
                                FillPagePSIIconSet(viewRect);
                            }
                        }
                        else if (PSIToolbarInt == 3)
                        {
                            {
                                FillPSIPageSensitivity();
                            }
                        }
                        //else if (PSIToolbarInt == 4)
                        //{
                        //    {
                        //        FillPagePSILoadIconset();
                        //    }
                        //}
                        else
                        {
                            FillPagePSIIconSet(viewRect);
                        }

                    }
                    break;
            }

            FlexibleSpace();
            Space(Text.LineHeight / 2);
            Label("", GrayLines, Height(1));
            Space(Text.LineHeight / 2);
            BeginHorizontal();
            if (Button("CBKF.Settings.RevertSettings".Translate()))
            {
                ResetBarSettings();
            }
            Space(Text.LineHeight / 2);
            if (Button("PSI.Settings.RevertSettings".Translate()))
            {
                ResetPSISettings();
            }
            FlexibleSpace();
            EndHorizontal();

            EndVertical();
            EndArea();

#if !NoCCL
            return 1000f;
#endif
        }

        private void LabelHeadline(string labelstring)
        {
            Space(Text.LineHeight);
            Label("", GrayLines, Height(1));
            Space(Text.LineHeight / 4);
            BeginHorizontal();
            FlexibleSpace();
            Label(labelstring, FontBold);
            FlexibleSpace();
            EndHorizontal();
            Space(Text.LineHeight / 2);
            Label("", GrayLines, Height(1));
            Space(Text.LineHeight / 2);
        }

        private void ResetBarSettings()
        {
            ColBarSettings = new SettingsColonistBar();
        }

        private void ResetPSISettings()
        {
            PsiSettings = new SettingsPSI();
        }

        private void FillPagePosition()
        {
            #region Vertical Alignment

            if (ColBarSettings.UseVerticalAlignment)
            {
#if !NoCCL
                listing.Indent();
#endif
                if (ColBarSettings.UseRightAlignment)
                {
                    BeginVertical(hoverBox);
                    ColBarSettings.UseCustomMarginRight = Toggle(ColBarSettings.UseCustomMarginRight, "CBKF.Settings.ColonistBarOffset".Translate() +
                       (int)ColBarSettings.MarginRightVer + ", " +
                       (int)ColBarSettings.MarginTopVerRight + ", " +
                       (int)ColBarSettings.MarginBottomVerRight
                       );
                    if (ColBarSettings.UseCustomMarginRight)
                    {
                        //    listing.Gap(3f);
                        ColBarSettings.MarginRightVer = HorizontalSlider(ColBarSettings.MarginRightVer, 0f, Screen.width / 12);
                        ColBarSettings.MarginTopVerRight = HorizontalSlider(ColBarSettings.MarginTopVerRight, 0f, Screen.height * 2 / 5);
                        ColBarSettings.MarginBottomVerRight = HorizontalSlider(ColBarSettings.MarginBottomVerRight, 0f, Screen.height * 2 / 5);
                    }
                    else
                    {
                        ColBarSettings.MarginRightVer = 21f;
                        ColBarSettings.MarginTopVerRight = 120f;
                        ColBarSettings.MarginBottomVerRight = 120f;
                        ColBarSettings.MaxColonistBarHeight = Screen.height - ColBarSettings.MarginTopVerRight - ColBarSettings.MarginBottomVerRight;
                        ColBarSettings.VerticalOffset = ColBarSettings.MarginTopVerRight / 2 - ColBarSettings.MarginBottomVerRight / 2;
                    }
                    EndVertical();

                }
                else
                {
                    BeginVertical(hoverBox);
                    ColBarSettings.UseCustomMarginLeft = Toggle(ColBarSettings.UseCustomMarginLeft, "CBKF.Settings.ColonistBarOffset".Translate() +
                       (int)ColBarSettings.MarginLeftVer + ", " +
                       (int)ColBarSettings.MarginTopVerLeft + ", " +
                       (int)ColBarSettings.MarginBottomVerLeft);
                    if (ColBarSettings.UseCustomMarginLeft)
                    {
                        ColBarSettings.MarginLeftVer = HorizontalSlider(ColBarSettings.MarginLeftVer, 0f, Screen.width / 12);
                        ColBarSettings.MarginTopVerLeft = HorizontalSlider(ColBarSettings.MarginTopVerLeft, 0f, Screen.height * 2 / 5);
                        ColBarSettings.MarginBottomVerLeft = HorizontalSlider(ColBarSettings.MarginBottomVerLeft, 0f, Screen.height * 2 / 5);
                    }
                    else
                    {
                        ColBarSettings.MarginLeftVer = 21f;
                        ColBarSettings.MarginTopVerLeft = 120f;
                        ColBarSettings.MarginBottomVerLeft = 120f;
                        ColBarSettings.MaxColonistBarHeight = Screen.height - ColBarSettings.MarginTopVerLeft - ColBarSettings.MarginBottomVerLeft;
                        ColBarSettings.VerticalOffset = ColBarSettings.MarginTopVerLeft / 2 - ColBarSettings.MarginBottomVerLeft / 2;
                    }
                    EndVertical();
                }



                //  listing.Gap(3f);
#if !NoCCL
                listing.Undent();
#endif
            }
            #endregion

            #region Horizontal alignment
            else
            {
#if !NoCCL
                listing.Indent();
#endif

                if (ColBarSettings.UseBottomAlignment)
                {
                    BeginVertical(hoverBox);
                    ColBarSettings.UseCustomMarginBottom = Toggle(ColBarSettings.UseCustomMarginBottom, "CBKF.Settings.ColonistBarOffset".Translate() +
                       (int)ColBarSettings.MarginBottomHor + ", " +
                       (int)ColBarSettings.MarginLeftHorBottom + ", " +
                       (int)ColBarSettings.MarginRightHorBottom);

                    if (ColBarSettings.UseCustomMarginBottom)
                    {
                        //    listing.Gap(3f);
                        ColBarSettings.MarginBottomHor = ColBarSettings.MarginBottomHor = HorizontalSlider(ColBarSettings.MarginBottomHor, 10, Screen.height / 12);
                        ColBarSettings.MarginLeftHorBottom = HorizontalSlider(ColBarSettings.MarginLeftHorBottom, 0f, Screen.width * 2 / 5);
                        ColBarSettings.MarginRightHorBottom = HorizontalSlider(ColBarSettings.MarginRightHorBottom, 0f, Screen.width * 2 / 5);
                    }
                    else
                    {
                        ColBarSettings.MarginBottomHor = 21f;
                        ColBarSettings.MarginLeftHorBottom = 160f;
                        ColBarSettings.MarginRightHorBottom = 160f;
                        ColBarSettings.MaxColonistBarWidth = Screen.width - ColBarSettings.MarginLeftHorBottom - ColBarSettings.MarginRightHorBottom;
                        ColBarSettings.HorizontalOffset = ColBarSettings.MarginLeftHorBottom / 2 - ColBarSettings.MarginRightHorBottom / 2;
                    }
                    EndVertical();
                }
                else
                {
                    BeginVertical(hoverBox);
                    ColBarSettings.UseCustomMarginTopHor = Toggle(ColBarSettings.UseCustomMarginTopHor, "CBKF.Settings.ColonistBarOffset".Translate() +
                       (int)ColBarSettings.MarginTopHor + ", " +
                       (int)ColBarSettings.MarginLeftHorTop + ", " +
                       (int)ColBarSettings.MarginRightHorTop);

                    if (ColBarSettings.UseCustomMarginTopHor)
                    {
                        //    listing.Gap(3f);
                        ColBarSettings.MarginTopHor = HorizontalSlider(ColBarSettings.MarginTopHor, 10, Screen.height / 12);
                        ColBarSettings.MarginLeftHorTop = HorizontalSlider(ColBarSettings.MarginLeftHorTop, 0f, Screen.width * 2 / 5);
                        ColBarSettings.MarginRightHorTop = HorizontalSlider(ColBarSettings.MarginRightHorTop, 0f, Screen.width * 2 / 5);
                    }
                    else
                    {
                        ColBarSettings.MarginTopHor = 21f;
                        ColBarSettings.MarginLeftHorTop = 160f;
                        ColBarSettings.MarginRightHorTop = 160f;
                        ColBarSettings.MaxColonistBarWidth = Screen.width - ColBarSettings.MarginLeftHorTop - ColBarSettings.MarginRightHorTop;
                        ColBarSettings.HorizontalOffset = ColBarSettings.MarginLeftHorTop / 2 - ColBarSettings.MarginRightHorTop / 2;
                    }
                    //  listing.Gap(3f);
                    EndVertical();


                    //  listing.Gap(3f);
                }
#if !NoCCL
                listing.Undent();
#endif
            }
            #endregion
        }

        private void FillPageOptions()
        {
            #region Size + Spacing
            BeginVertical(hoverBox);

            ColBarSettings.UseFixedIconScale = Toggle(ColBarSettings.UseFixedIconScale, "CBKF.Settings.FixedScale".Translate());

            ColBarSettings.UseCustomIconSize = Toggle(ColBarSettings.UseCustomIconSize, "CBKF.Settings.BasicSize".Translate() +
                (int)ColBarSettings.BaseSizeFloat + " - " +
                (int)ColBarSettings.BaseSpacingHorizontal + ", " +
            (int)ColBarSettings.BaseSpacingVertical
                );

            if (ColBarSettings.UseCustomIconSize)
            {
                ColBarSettings.BaseSizeFloat = HorizontalSlider(ColBarSettings.BaseSizeFloat, 16f, 128f);
                ColBarSettings.BaseSpacingHorizontal = HorizontalSlider(ColBarSettings.BaseSpacingHorizontal, 1f, 72f);
                ColBarSettings.BaseSpacingVertical = HorizontalSlider(ColBarSettings.BaseSpacingVertical, 1f, 96f);
            }
            else
            {
                ColBarSettings.BaseSizeFloat = 48f;
                ColBarSettings.BaseIconSize = 20f;
                ColBarSettings.BaseSpacingHorizontal = 24f;
                ColBarSettings.BaseSpacingVertical = 32f;
            }
            EndVertical();


            #endregion

            Space(Text.LineHeight / 2);
            BeginVertical(hoverBox);
            ColBarSettings.UseMoodColors = Toggle(ColBarSettings.UseMoodColors, "CBKF.Settings.UseMoodColors".Translate());
            if (ColBarSettings.UseMoodColors)
            {
                //      listing.Gap(3f);
                ColBarSettings.moodRectScale = HorizontalSlider(ColBarSettings.moodRectScale, 0.33f, 1f);
            }
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            ColBarSettings.UseWeaponIcons = Toggle(ColBarSettings.UseWeaponIcons, "CBKF.Settings.UseWeaponIcons".Translate());
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            ColBarSettings.UseGender = Toggle(ColBarSettings.UseGender, "CBKF.Settings.useGender".Translate());
            EndVertical();

            Space(Text.LineHeight / 2);

            #region Gender


#if !NoCCL
            if (barSettings.UseGender)
            {
            //    listing.Gap(3f);
                float indent = 24f;
                DrawMCMRegion(new Rect(indent, listing.CurHeight, listing.ColumnWidth - indent, 64f));
                listing.Gap(72f);
                listing.ColumnWidth = columnwidth / 2;
                listing.Indent();
                if (GUILayout.Button("CBKF.Settings.ResetColors".Translate()))
                {
                    femaleColorField.Value = new Color(1f, 0.64f, 0.8f, 1f);
                    maleColorField.Value = new Color(0.52f, 0.75f, 0.92f, 1f);
                }
                listing.Undent();
                listing.ColumnWidth = columnwidth;
                listing.Gap();
            }
#endif
            #endregion

            #region Camera
            BeginVertical(hoverBox);
            ColBarSettings.UseCustomPawnTextureCameraOffsets = Toggle(ColBarSettings.UseCustomPawnTextureCameraOffsets, "CBKF.Settings.PawnTextureCameraOffsets".Translate() +
                ColBarSettings.PawnTextureCameraHorizontalOffset.ToString("N2") + ", " +
                ColBarSettings.PawnTextureCameraVerticalOffset.ToString("N2") + ", " +
                ColBarSettings.PawnTextureCameraZoom.ToString("N2")
                );
            if (ColBarSettings.UseCustomPawnTextureCameraOffsets)
            {
                ColBarSettings.PawnTextureCameraHorizontalOffset = HorizontalSlider(ColBarSettings.PawnTextureCameraHorizontalOffset, 0.7f, -0.7f);
                ColBarSettings.PawnTextureCameraVerticalOffset = HorizontalSlider(ColBarSettings.PawnTextureCameraVerticalOffset, 0f, 1f);
                ColBarSettings.PawnTextureCameraZoom = HorizontalSlider(ColBarSettings.PawnTextureCameraZoom, 0.3f, 3f);
            }
            else
            {
                ColBarSettings.PawnTextureCameraHorizontalOffset = 0f;
                ColBarSettings.PawnTextureCameraVerticalOffset = 0.3f;
                ColBarSettings.PawnTextureCameraZoom = 1.28205f;
            }

            EndVertical();



            #endregion

            Space(Text.LineHeight / 2);
            BeginVertical(hoverBox);
            ColBarSettings.UseCustomDoubleClickTime = Toggle(ColBarSettings.UseCustomDoubleClickTime, "CBKF.Settings.DoubleClickTime".Translate() + ": " + ColBarSettings.DoubleClickTime.ToString("N2") + "s");
            if (ColBarSettings.UseCustomDoubleClickTime)
            {
                //       listing.Gap(3f);
                ColBarSettings.DoubleClickTime = HorizontalSlider(ColBarSettings.DoubleClickTime, 0.1f, 1.5f);
            }
            else
            {
                ColBarSettings.DoubleClickTime = 0.5f;
            }
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            ColBarSettings.useZoomToMouse = Toggle(ColBarSettings.useZoomToMouse, "CBKF.Settings.useZoomToMouse".Translate());
            EndVertical();
        }



#if !NoCCL
        private void DrawMCMRegion(Rect InRect)
        {
            Rect row = InRect;
            row.height = 24f;

            femaleColorField.Draw(row);
            barSettings.FemaleColor = femaleColorField.Value;

            row.y += 30f;

            maleColorField.Draw(row);
            barSettings.MaleColor = maleColorField.Value;
        }
#endif

#if !NoCCL
        private LabeledInput_Color femaleColorField = new LabeledInput_Color(barSettings.FemaleColor, "CBKF.Settings.FemaleColor".Translate());
        private LabeledInput_Color maleColorField = new LabeledInput_Color(barSettings.MaleColor, "CBKF.Settings.MaleColor".Translate());
#endif


        private void FillPagePSIIconSet(Rect viewRect)
        {

            BeginHorizontal();
            if (Button("PSI.Settings.IconSet".Translate() + PsiSettings.IconSet))
            {
                var options = new List<FloatMenuOption>();

                options.Add(new FloatMenuOption("PSI.Settings.Preset.0".Translate(), () =>
                {
                    try
                    {
                        PsiSettings.IconSet = "default";
                        SavePsiSettings();
                    }
                    catch (IOException)
                    {
                        Log.Error("PSI.Settings.LoadPreset.UnableToLoad".Translate() + "default");
                    }
                }));
                options.Add(new FloatMenuOption("PSI.Settings.Preset.1".Translate(), () =>
                {
                    try
                    {
                        PsiSettings.IconSet = "original";
                        SavePsiSettings();
                    }
                    catch (IOException)
                    {
                        Log.Error("PSI.Settings.LoadPreset.UnableToLoad".Translate() + "default");
                    }
                }));

                Find.WindowStack.Add(new FloatMenu(options));
            }
            Space(Text.LineHeight * 2);
            PsiSettings.ShowTargetPoint = Toggle(PsiSettings.ShowTargetPoint, "PSI.Settings.Visibility.TargetPoint".Translate());
            FlexibleSpace();
            EndHorizontal();


            _iconLimit = Mathf.FloorToInt(viewRect.width / 125f);


            Space(Text.LineHeight / 2);

            _scrollPosition = BeginScrollView(_scrollPosition);

            float boxWidth = viewRect.width / _iconLimit - 20;
            int num = 0;
            BeginHorizontal();

            DrawCheckboxArea("PSI.Settings.Visibility.Aggressive".Translate(), PSIMaterials[Icons.Aggressive], ref ColBarSettings.ShowAggressive, ref PsiSettings.ShowAggressive, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Dazed".Translate(), PSIMaterials[Icons.Dazed], ref ColBarSettings.ShowDazed, ref PsiSettings.ShowDazed, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Leave".Translate(), PSIMaterials[Icons.Leave], ref ColBarSettings.ShowLeave, ref PsiSettings.ShowLeave, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Draft".Translate(), PSIMaterials[Icons.Draft], ref ColBarSettings.ShowDraft, ref PsiSettings.ShowDraft, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Idle".Translate(), PSIMaterials[Icons.Idle], ref ColBarSettings.ShowIdle, ref PsiSettings.ShowIdle, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Unarmed".Translate(), PSIMaterials[Icons.Unarmed], ref ColBarSettings.ShowUnarmed, ref PsiSettings.ShowUnarmed, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Hungry".Translate(), PSIMaterials[Icons.Hungry], ref ColBarSettings.ShowHungry, ref PsiSettings.ShowHungry, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Sad".Translate(), PSIMaterials[Icons.Sad], ref ColBarSettings.ShowSad, ref PsiSettings.ShowSad, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Tired".Translate(), PSIMaterials[Icons.Tired], ref ColBarSettings.ShowTired, ref PsiSettings.ShowTired, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Sickness".Translate(), PSIMaterials[Icons.Sickness], ref ColBarSettings.ShowDisease, ref PsiSettings.ShowDisease, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Pain".Translate(), PSIMaterials[Icons.Pain], ref ColBarSettings.ShowPain, ref PsiSettings.ShowPain, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Health".Translate(), PSIMaterials[Icons.Health], ref ColBarSettings.ShowHealth, ref PsiSettings.ShowHealth, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Injury".Translate(), PSIMaterials[Icons.Effectiveness], ref ColBarSettings.ShowEffectiveness, ref PsiSettings.ShowEffectiveness, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Bloodloss".Translate(), PSIMaterials[Icons.Bloodloss], ref ColBarSettings.ShowBloodloss, ref PsiSettings.ShowBloodloss, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Hot".Translate(), PSIMaterials[Icons.Hot], ref ColBarSettings.ShowHot, ref PsiSettings.ShowHot, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Cold".Translate(), PSIMaterials[Icons.Freezing], ref ColBarSettings.ShowCold, ref PsiSettings.ShowCold, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Naked".Translate(), PSIMaterials[Icons.Naked], ref ColBarSettings.ShowNaked, ref PsiSettings.ShowNaked, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Drunk".Translate(), PSIMaterials[Icons.Drunk], ref ColBarSettings.ShowDrunk, ref PsiSettings.ShowDrunk, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.ApparelHealth".Translate(), PSIMaterials[Icons.ApparelHealth], ref ColBarSettings.ShowApparelHealth, ref PsiSettings.ShowApparelHealth, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Pacific".Translate(), PSIMaterials[Icons.Pacific], ref ColBarSettings.ShowPacific, ref PsiSettings.ShowPacific, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.NightOwl".Translate(), PSIMaterials[Icons.NightOwl], ref ColBarSettings.ShowNightOwl, ref PsiSettings.ShowNightOwl, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Greedy".Translate(), PSIMaterials[Icons.Greedy], ref ColBarSettings.ShowGreedy, ref PsiSettings.ShowGreedy, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Jealous".Translate(), PSIMaterials[Icons.Jealous], ref ColBarSettings.ShowJealous, ref PsiSettings.ShowJealous, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Lovers".Translate(), PSIMaterials[Icons.Love], ref ColBarSettings.ShowLovers, ref PsiSettings.ShowLovers, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Prosthophile".Translate(), PSIMaterials[Icons.Prosthophile], ref ColBarSettings.ShowProsthophile, ref PsiSettings.ShowProsthophile, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Prosthophobe".Translate(), PSIMaterials[Icons.Prosthophobe], ref ColBarSettings.ShowProsthophobe, ref PsiSettings.ShowProsthophobe, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.RoomStatus".Translate(), PSIMaterials[Icons.Crowded], ref ColBarSettings.ShowRoomStatus, ref PsiSettings.ShowRoomStatus, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.Bedroom".Translate(), PSIMaterials[Icons.Bedroom], ref ColBarSettings.ShowBedroom, ref PsiSettings.ShowBedroom, ref num, boxWidth);
            DrawCheckboxArea("PSI.Settings.Visibility.DeadColonists".Translate(), PSIMaterials[Icons.DeadColonist], ref ColBarSettings.ShowDeadColonists, ref PsiSettings.ShowDeadColonists, ref num, boxWidth);

            DrawCheckboxArea("PSI.Settings.Visibility.Pyromaniac".Translate(), PSIMaterials[Icons.Pyromaniac], ref ColBarSettings.ShowPyromaniac, ref PsiSettings.ShowPyromaniac, ref num, boxWidth);

            EndHorizontal();

            //  PsiSettings.ShowIdle = Toggle(PsiSettings.ShowIdle, "PSI.Settings.Visibility.Idle".Translate());
            //  PsiSettings.ShowUnarmed = Toggle(PsiSettings.ShowUnarmed, "PSI.Settings.Visibility.Unarmed".Translate());
            //  PsiSettings.ShowHungry = Toggle(PsiSettings.ShowHungry, "PSI.Settings.Visibility.Hungry".Translate());
            //  PsiSettings.ShowSad = Toggle(PsiSettings.ShowSad, "PSI.Settings.Visibility.Sad".Translate());
            //  PsiSettings.ShowTired = Toggle(PsiSettings.ShowTired, "PSI.Settings.Visibility.Tired".Translate());
            //  //
            //  PsiSettings.ShowDisease = Toggle(PsiSettings.ShowDisease, "PSI.Settings.Visibility.Sickness".Translate());
            //  PsiSettings.ShowPain = Toggle(PsiSettings.ShowPain, "PSI.Settings.Visibility.Pain".Translate());
            //  PsiSettings.ShowHealth = Toggle(PsiSettings.ShowHealth, "PSI.Settings.Visibility.Health".Translate());
            //  PsiSettings.ShowEffectiveness = Toggle(PsiSettings.ShowEffectiveness, "PSI.Settings.Visibility.Injury".Translate());
            //  PsiSettings.ShowBloodloss = Toggle(PsiSettings.ShowBloodloss, "PSI.Settings.Visibility.Bloodloss".Translate());
            //  //
            //  PsiSettings.ShowHot = Toggle(PsiSettings.ShowHot, "PSI.Settings.Visibility.Hot".Translate());
            //  PsiSettings.ShowCold = Toggle(PsiSettings.ShowCold, "PSI.Settings.Visibility.Cold".Translate());
            //  PsiSettings.ShowNaked = Toggle(PsiSettings.ShowNaked, "PSI.Settings.Visibility.Naked".Translate());
            //  PsiSettings.ShowDrunk = Toggle(PsiSettings.ShowDrunk, "PSI.Settings.Visibility.Drunk".Translate());
            //  PsiSettings.ShowApparelHealth = Toggle(PsiSettings.ShowApparelHealth, "PSI.Settings.Visibility.ApparelHealth".Translate());
            //  //
            //  PsiSettings.ShowPacific = Toggle(PsiSettings.ShowPacific, "PSI.Settings.Visibility.Pacific".Translate());
            //  PsiSettings.ShowNightOwl = Toggle(PsiSettings.ShowNightOwl, "PSI.Settings.Visibility.NightOwl".Translate());
            //  PsiSettings.ShowGreedy = Toggle(PsiSettings.ShowGreedy, "PSI.Settings.Visibility.Greedy".Translate());
            //  PsiSettings.ShowJealous = Toggle(PsiSettings.ShowJealous, "PSI.Settings.Visibility.Jealous".Translate());
            //  PsiSettings.ShowLovers = Toggle(PsiSettings.ShowLovers, "PSI.Settings.Visibility.Lovers".Translate());
            //  //
            //  PsiSettings.ShowProsthophile = Toggle(PsiSettings.ShowProsthophile, "PSI.Settings.Visibility.Prosthophile".Translate());
            //  PsiSettings.ShowProsthophobe = Toggle(PsiSettings.ShowProsthophobe, "PSI.Settings.Visibility.Prosthophobe".Translate());
            //  PsiSettings.ShowRoomStatus = Toggle(PsiSettings.ShowRoomStatus, "PSI.Settings.Visibility.RoomStatus".Translate());
            //  PsiSettings.ShowBedroom = Toggle(PsiSettings.ShowBedroom, "PSI.Settings.Visibility.Bedroom".Translate());
            //
            //  PsiSettings.ShowDeadColonists = Toggle(PsiSettings.ShowDeadColonists, "PSI.Settings.Visibility.ShowDeadColonists".Translate());
            //  PsiSettings.ShowPyromaniac = Toggle(PsiSettings.ShowPyromaniac, "PSI.Settings.Visibility.Pyromaniac".Translate());
            Space(Text.LineHeight / 2);
            EndScrollView();

        }

        private static int _iconLimit;

        private void DrawCheckboxArea(string translate, Material iconMaterial, ref bool colBarBool, ref bool psiBarBool, ref int iconInRow, float boxWidth)
        {


            if (iconInRow > _iconLimit - 1)
            {
                EndHorizontal();

                Space(Text.LineHeight / 2);

                BeginHorizontal();
                iconInRow = 0;
            }
            if (iconInRow > 0 && _iconLimit != 1)
                Space(Text.LineHeight / 2);

            BeginVertical();
            BeginHorizontal(GrayLines, Height(Text.LineHeight * 1.2f));
            FlexibleSpace();
            Label(translate, FontBold);
            FlexibleSpace();
            EndHorizontal();

            BeginHorizontal(DarkGrayBG);
            FlexibleSpace();

            BeginVertical();

            Space(Text.LineHeight / 2);

            if (iconMaterial != null)
            {
                Label(iconMaterial.mainTexture, Width(Text.LineHeight * 3f), Height(Text.LineHeight * 3f));
            }
            else
            {
                GUI.color = Color.red;
                Label("PSI.Settings.IconSet.IconNotAvailable".Translate(), Width(Text.LineHeight * 3f), Height(Text.LineHeight * 3f));
                GUI.color = Color.white;
            }
            Space(Text.LineHeight / 2);
            //      Label("PSI.Settings.VisibilityButton".Translate(), FontBold);
            colBarBool = Toggle(colBarBool, "CBKF.Settings.ColBarIconVisibility".Translate());
            psiBarBool = Toggle(psiBarBool, "CBKF.Settings.PSIIconVisibility".Translate());
            Space(Text.LineHeight / 2);

            EndVertical();

            FlexibleSpace();
            EndHorizontal();

            EndVertical();

            iconInRow++;
        }


        private void FillPagePSIOpacityAndColor()
        {

            _scrollPosition = BeginScrollView(_scrollPosition);

            BeginVertical(hoverBox);
            Label("PSI.Settings.IconOpacityAndColor.Opacity".Translate() + (PsiSettings.IconOpacity * 100).ToString("N0") + " %");
            PsiSettings.IconOpacity = HorizontalSlider(PsiSettings.IconOpacity, 0.05f, 1f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.IconOpacityAndColor.OpacityCritical".Translate() + (PsiSettings.IconOpacityCritical * 100).ToString("N0") + " %");
            PsiSettings.IconOpacityCritical = HorizontalSlider(PsiSettings.IconOpacityCritical, 0f, 1f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Toggle(PsiSettings.UseColoredTarget, "PSI.Settings.IconOpacityAndColor.UseColoredTarget".Translate());
            EndVertical();

            //if (listing.DoTextButton("PSI.Settings.ResetColors".Translate()))
            //{
            //    colorRedAlert = baseSettings.ColorRedAlert;
            //    Scribe_Values.LookValue(ref colorRedAlert, "colorRedAlert");
            //    colorInput.Value = colorRedAlert;
            //    PSI.SaveSettings();
            //}
            //
            //Rect row = new Rect(0f, listing.CurHeight, listing.ColumnWidth(), 24f);
            //
            //DrawMCMRegion(row);
            //
            //PSI.Settings.ColorRedAlert = colorInput.Value;
            //
            //listing.DoGap();
            //listing.DoGap();

            Space(Text.LineHeight / 2);
            EndScrollView();

            //  if (listing.DoTextButton("PSI.Settings.ReturnButton".Translate()))
            //      Page = "main";
        }

        private void FillPSIPageSizeArrangement()
        {
            BeginVertical(hoverBox);
            ColBarSettings.UsePsi = Toggle(ColBarSettings.UsePsi, "CBKF.Settings.UsePsiOnBar".Translate());
            if (ColBarSettings.UsePsi)
            {
                Space(Text.LineHeight / 2);

                BeginHorizontal();
                PsiBarPositionInt = Toolbar(PsiBarPositionInt, psiColBarStrings);
                FlexibleSpace();
                EndHorizontal();

                Space(Text.LineHeight / 2);

                Label("PSI.Settings.Arrangement.IconsPerColumn".Translate() + ColBarSettings.IconsInColumn);
                ColBarSettings.IconsInColumn = (int)HorizontalSlider(ColBarSettings.IconsInColumn, 3f, 7f);
            }
            EndVertical();

            Space(Text.LineHeight / 2);
            BeginVertical(hoverBox);
            PsiSettings.UsePsi = Toggle(PsiSettings.UsePsi, "PSI.Settings.UsePSI".Translate());
            if (PsiSettings.UsePsi)
            {
                Space(Text.LineHeight / 2);

                BeginHorizontal();
                PsiPositionInt = Toolbar(PsiPositionInt, psiColBarStrings);
                FlexibleSpace();
                EndHorizontal();
            }
            EndVertical();
            Space(Text.LineHeight / 2);

            _scrollPosition = BeginScrollView(_scrollPosition);


            var num = (int)(PsiSettings.IconSize * 4.5);

            if (num > 8)
                num = 8;
            else if (num < 0)
                num = 0;

            BeginVertical(hoverBox);
            Label("PSI.Settings.Arrangement.IconSize".Translate() + ("PSI.Settings.SizeLabel." + num).Translate());
            PsiSettings.IconSize = HorizontalSlider(PsiSettings.IconSize, 0.5f, 2f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label(string.Concat("PSI.Settings.Arrangement.IconPosition".Translate(), (int)(PsiSettings.IconDistanceX * 100.0), ", ", (int)(PsiSettings.IconDistanceY * 100.0)));
            PsiSettings.IconDistanceX = HorizontalSlider(PsiSettings.IconDistanceX, -2f, 2f);
            PsiSettings.IconDistanceY = HorizontalSlider(PsiSettings.IconDistanceY, -2f, 2f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label(string.Concat("PSI.Settings.Arrangement.IconOffset".Translate(), (int)(PsiSettings.IconOffsetX * 100.0), ", ", (int)(PsiSettings.IconOffsetY * 100.0)));
            PsiSettings.IconOffsetX = HorizontalSlider(PsiSettings.IconOffsetX, -2f, 2f);
            PsiSettings.IconOffsetY = HorizontalSlider(PsiSettings.IconOffsetY, -2f, 2f);
            EndVertical();

            Space(Text.LineHeight / 2);

            PsiSettings.IconsHorizontal = Toggle(PsiSettings.IconsHorizontal, "PSI.Settings.Arrangement.Horizontal".Translate());

            PsiSettings.IconsScreenScale = Toggle(PsiSettings.IconsScreenScale, "PSI.Settings.Arrangement.ScreenScale".Translate());

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Arrangement.IconsPerColumn".Translate() + PsiSettings.IconsInColumn);
            PsiSettings.IconsInColumn = (int)HorizontalSlider(PsiSettings.IconsInColumn, 1f, 7f);
            EndVertical();

            //   if (!listing.DoTextButton("PSI.Settings.ReturnButton".Translate()))
            //       return;
            //
            //   Page = "main";
            Space(Text.LineHeight / 2);
            EndScrollView();
        }


        private void FillPSIPageSensitivity()
        {

            BeginHorizontal();
            if (Button("PSI.Settings.LoadPresetButton".Translate()))
            {
                var options = new List<FloatMenuOption>
                {
                    new FloatMenuOption("Less Sensitive", () =>
                    {
                        try
                        {
                            PsiSettings.LimitBleedMult = 2f;
                            PsiSettings.LimitDiseaseLess = 1f;
                            PsiSettings.LimitEfficiencyLess = 0.28f;
                            PsiSettings.LimitFoodLess = 0.2f;
                            //        PsiSettings.LimitMoodLess = 0.2f;
                            PsiSettings.LimitRestLess = 0.2f;
                            PsiSettings.LimitApparelHealthLess = 0.5f;
                            PsiSettings.LimitTempComfortOffset = 3f;
                        }
                        catch (IOException)
                        {
                            Log.Error("PSI.Settings.LoadPreset.UnableToLoad".Translate() + "Less Sensitive");
                        }
                    }),
                    new FloatMenuOption("Standard", () =>
                    {
                        try
                        {
                            PsiSettings.LimitBleedMult = 3f;
                            PsiSettings.LimitDiseaseLess = 1f;
                            PsiSettings.LimitEfficiencyLess = 0.33f;
                            PsiSettings.LimitFoodLess = 0.25f;
                            //       PsiSettings.LimitMoodLess = 0.25f;
                            PsiSettings.LimitRestLess = 0.25f;
                            PsiSettings.LimitApparelHealthLess = 0.5f;
                            PsiSettings.LimitTempComfortOffset = 0f;
                        }
                        catch (IOException)
                        {
                            Log.Error("PSI.Settings.LoadPreset.UnableToLoad".Translate() + "Standard");
                        }
                    }),
                    new FloatMenuOption("More Sensitive", () =>
                    {
                        try
                        {
                            PsiSettings.LimitBleedMult = 4f;
                            PsiSettings.LimitDiseaseLess = 1f;
                            PsiSettings.LimitEfficiencyLess = 0.45f;
                            PsiSettings.LimitFoodLess = 0.3f;
                            //      PsiSettings.LimitMoodLess = 0.3f;
                            PsiSettings.LimitRestLess = 0.3f;
                            PsiSettings.LimitApparelHealthLess = 0.5f;
                            PsiSettings.LimitTempComfortOffset = -3f;
                        }
                        catch (IOException)
                        {
                            Log.Error("PSI.Settings.LoadPreset.UnableToLoad".Translate() + "More Sensitive");
                        }
                    })
                };

                Find.WindowStack.Add(new FloatMenu(options));
            }

            FlexibleSpace();
            EndHorizontal();

            Space(Text.LineHeight/2);

            _scrollPosition = BeginScrollView(_scrollPosition);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.Bleeding".Translate() + ("PSI.Settings.Sensitivity.Bleeding." + Math.Round(PsiSettings.LimitBleedMult - 0.25)).Translate());
            PsiSettings.LimitBleedMult = HorizontalSlider(PsiSettings.LimitBleedMult, 0.5f, 5f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.Injured".Translate() + (int)(PsiSettings.LimitEfficiencyLess * 100.0) + " %");
            PsiSettings.LimitEfficiencyLess = HorizontalSlider(PsiSettings.LimitEfficiencyLess, 0.01f, 0.99f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.Food".Translate() + (int)(PsiSettings.LimitFoodLess * 100.0) + " %");
            PsiSettings.LimitFoodLess = HorizontalSlider(PsiSettings.LimitFoodLess, 0.01f, 0.99f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.Rest".Translate() + (int)(PsiSettings.LimitRestLess * 100.0) + " %");
            PsiSettings.LimitRestLess = HorizontalSlider(PsiSettings.LimitRestLess, 0.01f, 0.99f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.ApparelHealth".Translate() + (int)(PsiSettings.LimitApparelHealthLess * 100.0) + " %");
            PsiSettings.LimitApparelHealthLess = HorizontalSlider(PsiSettings.LimitApparelHealthLess, 0.01f, 0.99f);
            EndVertical();

            Space(Text.LineHeight / 2);

            BeginVertical(hoverBox);
            Label("PSI.Settings.Sensitivity.Temperature".Translate() + (int)PsiSettings.LimitTempComfortOffset + " °C");
            PsiSettings.LimitTempComfortOffset = HorizontalSlider(PsiSettings.LimitTempComfortOffset, -10f, 10f);
            EndVertical();

            Space(Text.LineHeight / 2);
            EndScrollView();

            //  if (!listing.DoTextButton("PSI.Settings.ReturnButton".Translate()))
            //      return;
            //
            //  Page = "main";
        }


#if NoCCL
        public void ExposeData()
#else
        public override void ExposeData()
#endif
        {
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomMarginTopHor, "useCustomMarginTopHor", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomMarginBottom, "UseCustomMarginBottom", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomMarginLeft, "useCustomMarginLeftRightVer", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomMarginRight, "UseCustomMarginRight", false);


            Scribe_Values.LookValue(ref ColBarSettings.UseCustomIconSize, "useCustomIconSize", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseFixedIconScale, "useFixedIconScale", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomPawnTextureCameraOffsets, "useCustomPawnTextureCameraZoom", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseCustomDoubleClickTime, "useCustomDoubleClick", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseGender, "useGender", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseVerticalAlignment, "useVerticalAlignment", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseRightAlignment, "useRightAlignment", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseBottomAlignment, "useBottomAlignment", false);

            Scribe_Values.LookValue(ref ColBarSettings.UseMoodColors, "UseMoodColors", false);
            Scribe_Values.LookValue(ref ColBarSettings.UseWeaponIcons, "UseWeaponIcons", false);

            Scribe_Values.LookValue(ref ColBarSettings.MarginTopHor, "MarginTopHor", 21f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginBottomHor, "MarginBottomHor", 21f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginLeftHorTop, "MarginLeftHorTop", 160f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginRightHorTop, "MarginRightHorTop", 160f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginLeftHorBottom, "MarginLeftHorBottom", 160f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginRightHorBottom, "MarginRightHorBottom", 160f);

            Scribe_Values.LookValue(ref ColBarSettings.MarginTopVerLeft, "MarginTopVerLeft", 120f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginBottomVerLeft, "MarginBottomVerLeft", 120f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginTopVerRight, "MarginTopVerRight", 120f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginBottomVerRight, "MarginBottomVerRight", 120f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginLeftVer, "MarginLeftVer", 21f);
            Scribe_Values.LookValue(ref ColBarSettings.MarginRightVer, "MarginRightVer", 21f);

            Scribe_Values.LookValue(ref ColBarSettings.HorizontalOffset, "HorizontalOffset", 0f);
            Scribe_Values.LookValue(ref ColBarSettings.VerticalOffset, "VerticalOffset", 0f);


            Scribe_Values.LookValue(ref ColBarSettings.BaseSpacingHorizontal, "BaseSpacingHorizontal", 24f);
            Scribe_Values.LookValue(ref ColBarSettings.BaseSpacingVertical, "BaseSpacingVertical", 32f);
            Scribe_Values.LookValue(ref ColBarSettings.BaseSizeFloat, "BaseSizeFloat", 48f);
            Scribe_Values.LookValue(ref ColBarSettings.BaseIconSize, "BaseIconSize", 20f);
            Scribe_Values.LookValue(ref ColBarSettings.PawnTextureCameraHorizontalOffset, "PawnTextureCameraHorizontalOffset", 0f);
            Scribe_Values.LookValue(ref ColBarSettings.PawnTextureCameraVerticalOffset, "PawnTextureCameraVerticalOffset", 0.3f);
            Scribe_Values.LookValue(ref ColBarSettings.PawnTextureCameraZoom, "PawnTextureCameraZoom", 1.28205f);
            Scribe_Values.LookValue(ref ColBarSettings.MaxColonistBarWidth, "MaxColonistBarWidth");
            Scribe_Values.LookValue(ref ColBarSettings.MaxColonistBarHeight, "MaxColonistBarHeight");


            Scribe_Values.LookValue(ref ColBarSettings.DoubleClickTime, "DoubleClickTime", 0.5f);

            Scribe_Values.LookValue(ref ColBarSettings.FemaleColor, "FemaleColor");
            Scribe_Values.LookValue(ref ColBarSettings.MaleColor, "MaleColor");

            Scribe_Values.LookValue(ref ColBarSettings.MaxRows, "MaxRows");
            Scribe_Values.LookValue(ref ColBarSettings.SortBy, "SortBy");
            Scribe_Values.LookValue(ref ColBarSettings.useZoomToMouse, "useZoomToMouse");
            Scribe_Values.LookValue(ref ColBarSettings.moodRectScale, "moodRectScale");


#if !NoCCL
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                femaleColorField.Value = barSettings.FemaleColor;
                maleColorField.Value = barSettings.MaleColor;
            }
#endif
        }

        #endregion

    }
}
