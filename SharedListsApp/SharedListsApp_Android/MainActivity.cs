using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Custom.Views;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using SharedListsApp.Entities;
using Android.Content;
using System;
using SharedListsApp;
using ModernHttpClient;

namespace SharedListsApp_Android
{
    [Activity(Label = "Shared Lists App", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme1")]
    public class MainActivity : AppCompatActivity
    {

        private RecyclerViewEmptySpacesSupport MyRecyclerList;
        private MyPostListAdapter Adapter;
        private List<Post> Posts;
        private TextView EmptyText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Listas Locas" ;

            MyRecyclerList = FindViewById<RecyclerViewEmptySpacesSupport>(Resource.Id.MyRecyclerList);
            EmptyText = FindViewById<TextView>(Resource.Id.empty_text);

            Posts = new List<Post>();
            Adapter = new MyPostListAdapter(Posts);

            MyRecyclerList.EmptyView = EmptyText;
            MyRecyclerList.SetLayoutManager(new LinearLayoutManager(this));
            MyRecyclerList.SetAdapter(Adapter);

            LoadData();
        }

        private async void LoadData()
        {
            RestClient restClient = new RestClient(new NativeMessageHandler());

            List<Post> posts = await restClient.GetTestPostList();

            Posts.Clear();
            Posts.AddRange(posts);
            Adapter.NotifyDataSetChanged();
        }
    }

    public class MyPostListAdapter : RecyclerView.Adapter
    {

        private Context c;
        private List<Post> list;

        public MyPostListAdapter(List<Post> _list)
        {
            list = _list;
        }

        public override int ItemCount => list.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PostViewHolder view = holder as PostViewHolder;
            Post post = list[position];

            view.rowTitle.Text = post.Title;
            view.rowUser.Text = post.UserId;
            view.rowDescription.Text = post.Body;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (c == null)
                c = parent.Context;
            return new PostViewHolder(
                LayoutInflater.From(c).Inflate(Resource.Layout.MyRow, parent, false)
                );
        }

        public class PostViewHolder : RecyclerView.ViewHolder
        {
            private View root;
            public TextView rowTitle { get; set; }
            public TextView rowUser { get; set; }
            public TextView rowDescription { get; set; }

            public PostViewHolder(View root) : base(root)
            {
                this.root = root;
                rowTitle = root.FindViewById<TextView>(Resource.Id.rowTitle);
                rowUser = root.FindViewById<TextView>(Resource.Id.rowUser);
                rowDescription = root.FindViewById<TextView>(Resource.Id.rowDesc);
            }

        }

    }

}

