import 'package:flutter/material.dart';
import 'package:get/get_navigation/get_navigation.dart';

class App {
  Future<void> run() async {}
}

class AppWidget extends StatelessWidget {
  AppWidget({super.key, required this.title});

  final String title;

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      home: Text('Hello'),
    );
  }
}
