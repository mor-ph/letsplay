import 'package:dynamic_treeview/dynamic_treeview.dart';
import 'package:flutter/material.dart';

class Category extends BaseData {
  int id;
  String name;
  int parentId;
  IconData categoryIcon;
  bool isSelected = false;

  Category({@required this.id, @required this.name, @required this.parentId, @required this.categoryIcon, @required this.isSelected});

  @override
  Map<String, Category> getExtraData() {
    return {'key': this};
  }

  @override
  String getId() {
    return this.id.toString();
  }

  @override
  String getParentId() {
    return this.parentId.toString();
  }

  @override
  String getTitle() {
    return this.name;
  }
}
