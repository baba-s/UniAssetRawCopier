using System.IO;
using UnityEditor;

namespace Kogane.Internal
{
	internal static class AssetRawCopier
	{
		private const string ITEM_NAME = "Assets/Copy Raw";

		[MenuItem( ITEM_NAME )]
		private static void Copy()
		{
			var asset = Selection.activeObject;
			var path  = AssetDatabase.GetAssetPath( asset );
			var text  = File.ReadAllText( path );

			EditorGUIUtility.systemCopyBuffer = text;
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool CanCopy()
		{
			var asset = Selection.activeObject;
			var path  = AssetDatabase.GetAssetPath( asset );

			if ( string.IsNullOrWhiteSpace( path ) ) return false;
			if ( !File.Exists( path ) ) return false;

			return true;
		}
	}
}