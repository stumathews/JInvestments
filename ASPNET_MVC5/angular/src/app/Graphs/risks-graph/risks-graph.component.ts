import { Component, NgModule, OnInit, AfterViewInit, OnDestroy, ViewEncapsulation  } from '@angular/core';
import { miserables } from './miserables';
import { GraphData } from '../../Models/GraphData';
import * as d3 from 'd3';

interface DataType {
   x: any;
    y: any;
    id: any;
  }

@Component({
  selector: 'app-risks-graph',
  templateUrl: './risks-graph.component.html',
  styleUrls: ['./risks-graph.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RisksGraphComponent implements OnInit, AfterViewInit, OnDestroy  {
  name: string;
  svg;
  color;
  simulation;
  link;
  node;
  constructor() { }
  ngOnInit() {

  }

  ngAfterViewInit() {
    this.svg = d3.select('svg');
    const width = +this.svg.attr('width');
    const height = +this.svg.attr('height');

    this.color = d3.scaleOrdinal(d3.schemeCategory20);
    this.simulation = d3.forceSimulation()
        .force('link', d3.forceLink().id(function(d: DataType) { return d.id; }))
        .force('charge', d3.forceManyBody())
        .force('center', d3.forceCenter(width / 2, height / 2));
    this.render(miserables);
  }
  ticked() {
    this.link
        .attr('x1', function(d) { return d.source.x; })
        .attr('y1', function(d) { return d.source.y; })
        .attr('x2', function(d) { return d.target.x; })
        .attr('y2', function(d) { return d.target.y; });

    this.node
        .attr('cx', function(d) { return d.x; })
        .attr('cy', function(d) { return d.y; });
  }
  render(graph) {
    this.link = this.svg.append('g')
    .attr('class', 'links')
    .selectAll('line')
    .data(graph.links)
    .enter().append('line')
      .attr('stroke-width', function(d) { return Math.sqrt(d.value); });

    this.node = this.svg.append('g')
    .attr('class', 'nodes')
    .selectAll('circle')
    .data(graph.nodes)
    .enter().append('circle')
      .attr('r', 5)
      .attr('fill', (d) => this.color(d.group))
      .call(d3.drag()
          .on('start', (d) => this.dragstarted(d))
          .on('drag', (d) => this.dragged(d))
          .on('end', (d) => this.dragended(d)));

    this.node.append('title')
      .text(function(d) { return d.id; });

    this.simulation
      .nodes(graph.nodes)
      .on('tick', () =>  this.ticked());

    this.simulation.force('link')
      .links(graph.links);
  }

  dragged(d) {
    d.fx = d3.event.x;
    d.fy = d3.event.y;
  }

  dragended(d) {
    if (!d3.event.active) { this.simulation.alphaTarget(0); }
    d.fx = null;
    d.fy = null;
  }

  dragstarted(d) {
    if (!d3.event.active) { this.simulation.alphaTarget(0.3).restart(); }
    d.fx = d.x;
    d.fy = d.y;
  }

  ngOnDestroy() {
  }
}
