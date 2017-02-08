// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VocabQuiz_SizeClasses
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AnswerLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HeadingLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel QuestionLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AnswerLabel != null) {
                AnswerLabel.Dispose ();
                AnswerLabel = null;
            }

            if (BButton != null) {
                BButton.Dispose ();
                BButton = null;
            }

            if (CButton != null) {
                CButton.Dispose ();
                CButton = null;
            }

            if (DButton != null) {
                DButton.Dispose ();
                DButton = null;
            }

            if (HeadingLabel != null) {
                HeadingLabel.Dispose ();
                HeadingLabel = null;
            }

            if (QuestionLabel != null) {
                QuestionLabel.Dispose ();
                QuestionLabel = null;
            }
        }
    }
}