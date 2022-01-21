

window.toolsAppDemo = {};

window.toolsAppDemo.setFocus = function (control) {
  control.focus();
};




window.refreshCarsCaller = (dotnetHelper) => {
  window.dotnetHelper = dotnetHelper;
  console.log(window.dotnetHelper);

  if (window.refreshCarsHandle) {
    window.clearTimeout(window.refreshCarsHandle);
  }

  window.refreshCarsHandle = setTimeout(() => {
    console.log("refreshing cars");
    dotnetHelper.invokeMethodAsync('ToolsApp', 'RefreshCarsCaller');
  },  5000);
}
