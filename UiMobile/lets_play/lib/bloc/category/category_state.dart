
import 'package:flutter/material.dart';
import 'package:lets_play/model/category.dart';
import 'package:lets_play/model/event.dart';

abstract class EventCategorisedState {}

class EventCategorUninitializedState extends EventCategorisedState {}

class EventCategoryFetchingState extends EventCategorisedState {}

class EventCategoryFetchedState extends EventCategorisedState {
  final List<Event> events;
  final List<Category> subCategories;
  final Category category;
  EventCategoryFetchedState({@required this.events, @required this.subCategories, @required this.category});

  @override
  List<Object> get props => [events];
}

class EventCategoryErrorState extends EventCategorisedState {}

class EventCategoryEmptyState extends EventCategorisedState {
  final List<Event> events;
  EventCategoryEmptyState({@required this.events});

  @override
  List<Object> get props => [events];
}