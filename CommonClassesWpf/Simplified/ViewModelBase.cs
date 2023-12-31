using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace Simplified
{
    /// <summary>Base class for ViewModel.</summary>
    public abstract partial class ViewModelBase : BaseInpc
    {
        /// <summary>Returns <see langword="true"/> if the call occurs
        /// During Development mode.<br/>
        /// Can be used to create a Design Time Data Context
        /// different from the Runtime Data Context.<br/>
        /// Initialized with the value returned by the method
        /// <see cref="DesignerProperties.GetIsInDesignMode(DependencyObject)"/>
        /// for new DependencyObject().</summary>
        public static bool IsInDesignModeStatic { get; } = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        /// <summaryReturns <see langword="true"/> if the call occurs
        /// During Development mode.<br/>
        /// The value of the <see cref="IsInDesignModeStatic"/> property is initialized.<br/>
        /// In derived classes, maybe through constructors
        /// <see cref="ViewModelBase(bool)"/> and <see cref="ViewModelBase(Dispatcher, bool)"/>,
        /// a different value is specified.</summary>
        public bool IsInDesignMode { get; } = IsInDesignModeStatic;

        /// <summary>Constructor with property values <see cref="Dispatcher"/>
        /// and <see cref="IsInDesignMode"/> specified during initialization.</summary>
        protected ViewModelBase() { }


        /// <summary>Constructor with property value
        /// <see cref="Dispatcher"/> specified during initialization.</summary>
        /// <param name="isInDesignMode">Value for the <see cref="IsInDesignMode"/> property.</param>
        protected ViewModelBase(bool isInDesignMode)
        {
            IsInDesignMode = isInDesignMode;
        }
    }
}
