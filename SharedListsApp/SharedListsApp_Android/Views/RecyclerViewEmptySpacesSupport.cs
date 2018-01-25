using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;

namespace Android.Custom.Views
{
    [Register("android.custom.views.RecyclerViewEmptySpacesSupport")]
    public class RecyclerViewEmptySpacesSupport : RecyclerView
    {

        // Variables
        private View emptyView;
        public View EmptyView
        {
            get { return emptyView; }
            set
            {
                handle_empty_event();
                emptyView = value;
            }
        }

        private OnNoChildClick onNoChildClickListener;
        private OnNoChildClick OnNoChildClickListener
        { get { return onNoChildClickListener; } set {
                handle_empty_event();
                onNoChildClickListener = value;
            } }
        private EmptyListObserver emptyListObserver;

        public RecyclerViewEmptySpacesSupport(Context context) : base(context) { }
        public RecyclerViewEmptySpacesSupport(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public RecyclerViewEmptySpacesSupport(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }
        public RecyclerViewEmptySpacesSupport(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        private class EmptyListObserver : AdapterDataObserver
        {
            private RecyclerViewEmptySpacesSupport Parent;
            public EmptyListObserver(RecyclerViewEmptySpacesSupport parent)
            {
                Parent = parent;
            }
            public override void OnChanged()
            {
                base.OnChanged();
                Adapter adapter = Parent.GetAdapter();
                if (adapter != null && Parent.EmptyView != null)
                {
                    if (adapter.ItemCount == 0)
                    {
                        Parent.EmptyView.Visibility = ViewStates.Visible;
                        Parent.Visibility = ViewStates.Gone;
                    }
                    else
                    {
                        Parent.EmptyView.Visibility = ViewStates.Gone;
                        Parent.Visibility = ViewStates.Visible;
                    }
                }
            }
        }

        public override void SetAdapter(Adapter adapter)
        {
            base.SetAdapter(adapter);

            if (emptyListObserver == null)
                emptyListObserver = new EmptyListObserver(this);

            if (adapter != null) adapter.RegisterAdapterDataObserver(emptyListObserver);
            emptyListObserver.OnChanged();
        }


        public override bool DispatchTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down
                && FindChildViewUnder(e.GetX(), e.GetY()) == null)
                OnNoChildClickListener?.Invoke();
            return base.DispatchTouchEvent(e);
        }


        private void handle_empty_event()
        {
            if (EmptyView != null && OnNoChildClickListener != null)
                EmptyView.Click += delegate
                {
                    OnNoChildClickListener();
                };
        }

        public delegate void OnNoChildClick();

    }
}