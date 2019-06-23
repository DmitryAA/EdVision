<template>
	<section class="row b-un-list">
		<article class="b-un-list__item" v-for="item in info">
			<router-link :to="{ path: '/university/' + item.Id}">
				<div class="b-un-list__name">{{item.Name}}</div>
				<div class="b-un-list__city">{{item.Address.City.Name}}</div>
				<div class="b-un-list__line">
					<div class="b-un-list__count">Проектов:<br>{{item.FederalRating}}</div>
					<div class="b-un-list__logo"></div>
					<div class="b-un-list__rating">Рейтинг:<br>50</div>
				</div>
			</router-link>
		</article>
	</section>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'universities',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/universities/')
				.then(response => (this.info = response.data));
		}
	};
</script>
